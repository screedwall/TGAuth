using System.Diagnostics;

namespace TGAuth
{
    public partial class WriteToBot : Form
    {
        string username;
        string password;
        Settings_t settings;

        public WriteToBot(string username, string password, Settings_t settings)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.settings = settings;
        }

        //обработчик нажатия на ссылку
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/AmerkhanovaBot") { UseShellExecute = true });
        }

        //обработчик кнопки "подтвердить"
        private async void button1_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["username"] = username;
            request["password"] = password;
            request["telegram_id"] = chatId_tb.Text;

            var res = await Client.sendRequest(settings.ip, settings.port, OperTypes.register, request);

            //если сервер прислал ответ
            if (res != null)
            {
                //если статус ответа ок
                if (res == Response.OK.ToString())
                {
                    MessageBox.Show("Пользователь успешно зарегистрирован!", "Успешно", MessageBoxButtons.OK);
                    Close();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже зарегистрирован!", "Ошибка", MessageBoxButtons.OK);
                    Close();
                }
            }
        }
    }
}