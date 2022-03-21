namespace TGAuth
{
    public partial class TGAuth : Form
    {
        public TGAuth()
        {
            InitializeComponent();
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            List<IDictionary<string, string>>  args = new List<IDictionary<string, string>>();
            IDictionary<string, string> arg = new Dictionary<string, string>();
            arg["username"] = username_tb.Text.ToLower();
            arg["password"] = password_tb.Text.ToLower();
            args.Add(arg);
            JsonMsg msg = new JsonMsg(OperTypes.login, args);

            Client client = new Client("localhost", 80);
            JsonMsg res = client.send(msg.ToJson());

            if (res.status == Response.OK)
            {
                _2FA twoFactor = new _2FA(username_tb.Text.ToLower());
                twoFactor.Show();
            } else {
                MessageBox.Show("Такой пользователь не зарегистрирован!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username_tb.TextLength == 0 || password_tb.TextLength == 0)
            {
                MessageBox.Show("Не заполнен логин или пароль", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                WriteToBot writeToBotForm = new WriteToBot(username_tb.Text.ToLower(), password_tb.Text);
                writeToBotForm.Show();
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

