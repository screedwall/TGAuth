using System.Diagnostics;
using Newtonsoft.Json;

namespace TGAuth
{
    public partial class WriteToBot : Form
    {
        string username;
        string password;

        public WriteToBot(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
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

            //Отправка запроса на регистрацию
            var res = await Client.sendRequest(OperTypes.register, request);

            //если сервер прислал ответ
            if (res != null)
            {
                //распаковка сообщения из стоки в объект
                var msg = JsonConvert.DeserializeObject<Msg<Response>>(res);
                //если статус ответа ок
                if (msg.status == Response.OK)
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