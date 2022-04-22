using Newtonsoft.Json;

namespace TGAuth
{
    public partial class _2FA : Form
    {
        string username;

        public _2FA(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        //обработчик кнопки "проверить"
        private async void button1_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["username"] = username;
            request["code"] = textBox1.Text;

            //отправляем запрос на проверку кода
            var res = await Client.sendRequest(OperTypes.checkCode, request);

            //если сервер прислал ответ
            if (res != null)
            {
                //распаковка сообщения из стоки в объект
                var msg = JsonConvert.DeserializeObject<Msg<Token>>(res);
                //если статус ответа ок
                if (msg.status == Response.OK)
                {
                    //заполняем информацию о токенах
                    Settings.settings.token = msg.data[0];
                    //закрываем форму
                    this.Close();
                    //открываем форму личного кабинета
                    Account account = new Account();
                    account.Show();
                }
                else
                {
                    MessageBox.Show("Неверный код!", "Error", MessageBoxButtons.OK);
                }
            }
        }
    }
}
