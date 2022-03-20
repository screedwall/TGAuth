using System.Diagnostics;
using System.Data.SqlClient;

namespace TGAuth
{
    public partial class WriteToBot : Form
    {
        string username;
        string password;
        SqlConnection db_conn;
        Bot bot;
        public WriteToBot(string username, string password, SqlConnection db_conn)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.db_conn = db_conn;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/AmerkhanovaBot") { UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand queryInsertPendingRegister = new SqlCommand(String.Format("INSERT INTO users (username, password, chat_id, registered) " +
                                                                                     "VALUES ('{0}', '{1}', {2}, 1)", username, password, chatId_tb.Text), db_conn);
            queryInsertPendingRegister.Connection.Open();
            queryInsertPendingRegister.ExecuteNonQuery();
            queryInsertPendingRegister.Connection.Close();

            MessageBox.Show("Пользователь успешно зарегистрирован!", "Успешно", MessageBoxButtons.OK);

            Close();
        }
        private void chatId_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}