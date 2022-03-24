using System.Diagnostics;

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
        private void button1_Click(object sender, EventArgs e)
        {
            //создаём пустой список параметров для отправки на сервер
            List<IDictionary<string, string>> args = new List<IDictionary<string, string>>();
            //создаём пустой параметр
            IDictionary<string, string> arg = new Dictionary<string, string>();
            //заполняем логин
            arg["username"] = username;
            //заполняем пароль
            arg["password"] = password;
            //заполняем telegram id
            arg["chatId"] = chatId_tb.Text;
            //добавляем параметр в список
            args.Add(arg);
            //создаём сообщение
            JsonMsg msg = new JsonMsg(OperTypes.register, args);

            //подключение к серверу
            Client client = new Client("localhost", 80);
            //отправка сообщения и ожидание результата
            JsonMsg res = client.send(msg.ToJson());

            //если сервер прислал ответ
            if (res != null)
            {
                //если статус ответа ок
                if (res.status == Response.OK)
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