using System.Data.SqlClient;

namespace TGAuth
{
    public partial class TGAuth : Form
    {
        Bot bot = new Bot();
        SqlConnection db_conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tgauth;Integrated Security=True");
        public TGAuth()
        {
            InitializeComponent();
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            SqlCommand queryUser = new SqlCommand(String.Format("SELECT * FROM users WHERE username='{0}' AND password='{1}' AND registered=1", username_tb.Text.ToLower(), password_tb.Text.ToLower()), db_conn);
            queryUser.Connection.Open();
            SqlDataReader reader = queryUser.ExecuteReader();
            int count = 0;
            var rand = new Random();
            var code = rand.Next(999999).ToString("D6");
            while (reader.Read())
            {
                var id = reader["id"];
                var username = reader["username"];
                long chat_id = (long)reader["chat_id"];
                count++;
                queryUser.Connection.Close();
                SqlCommand queryUpdateRegistration = new SqlCommand(String.Format("UPDATE users " +
                                                                                  "SET code='{0}' " +
                                                                                  "WHERE id={1}", code, id), db_conn);
                queryUpdateRegistration.Connection.Open();
                queryUpdateRegistration.ExecuteNonQuery();
                queryUpdateRegistration.Connection.Close();
                bot.SendMsg(chat_id, String.Format("Привет, {0}! Твой код для входа: {1}", username, code));
                break;
            }
            if (queryUser.Connection.State == System.Data.ConnectionState.Open)
                queryUser.Connection.Close();

            if (count == 0)
            {
                MessageBox.Show("Такой пользователь не зарегистрирован!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                _2FA twoFactor = new _2FA(code);
                twoFactor.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand queryUser = new SqlCommand(String.Format("SELECT * FROM users WHERE username='{0}' AND password='{1}' AND registered=1", username_tb.Text.ToLower(), password_tb.Text.ToLower()), db_conn);
            queryUser.Connection.Open();
            SqlDataReader reader = queryUser.ExecuteReader();
            int count = 0;
            var username = username_tb.Text;
            var password = password_tb.Text;
            while (reader.Read())
            {
                count++;
            }
            if (queryUser.Connection.State == System.Data.ConnectionState.Open)
                queryUser.Connection.Close();

            if (username_tb.TextLength == 0 || password_tb.TextLength == 0)
            {
                MessageBox.Show("Не заполнен логин или пароль", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (count == 0)
                {
                    WriteToBot writeToBotForm = new WriteToBot(username_tb.Text.ToLower(), password_tb.Text, db_conn);
                    writeToBotForm.Show();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже зарегистрирован!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void username_tb_TextChanged(object sender, EventArgs e)
        {

        }
        private void password_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

