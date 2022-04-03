namespace TGAuth
{
    public partial class _2FA : Form
    {
        string username;
        Settings_t settings;

        public _2FA(string username, Settings_t settings)
        {
            this.username = username;
            this.settings = settings;
            InitializeComponent();
        }

        //обработчик кнопки "проверить"
        private async void button1_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["username"] = username;
            request["code"] = textBox1.Text;

            var res = await Client.sendRequest(settings.ip, settings.port, OperTypes.checkCode, request);

            //если сервер прислал ответ
            if (res != null)
            {
                //если статус ответа ок
                if (res == Response.OK.ToString())
                {
                    //закрываем форму
                    this.Close();
                    MessageBox.Show("Вы успешно вошли!", "LogIn", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Неверный код!", "Error", MessageBoxButtons.OK);
                }
            }
        }
    }
}
