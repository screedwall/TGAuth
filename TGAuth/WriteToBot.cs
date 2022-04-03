using System.Diagnostics;
using System.Data.SqlClient;

namespace TGAuth
{
    public partial class WriteToBot : Form
    {
        string username;
        string password;
        DBase db;
        Bot bot;
        public WriteToBot(string username, string password, DBase db)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.db = db;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/AmerkhanovaBot") { UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //добавление пользователя в таблицу
            db.Exec(String.Format("INSERT INTO users (username, password, telegram_id) " +
                                  "VALUES ('{0}', '{1}', {2})", username, password, chatId_tb.Text));
            //получаем id нового пользователя
            var sqlResponse = db.Select(String.Format("SELECT * FROM users WHERE username='{0}' AND password='{1}'", username, password));
            int user_id = 0;
            for (int j = 0; j < sqlResponse.Count; j++)
            {
                var row = sqlResponse[j];
                user_id = Int32.Parse(row["Id"]);
            }
            //запоминаем текущее время в формате SQL
            DateTime dateTime = DateTime.Now;
            string sqlFormattedDate = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            //добавляем новую запись в таблицу кодов, которую в дальнейшем будем обновлять
            db.Exec(String.Format("INSERT INTO codes (user_id, code, date) " +
                                  "VALUES ({0}, {1}, '{2}')", user_id, 0, sqlFormattedDate));
            Close();
        }
    }
}