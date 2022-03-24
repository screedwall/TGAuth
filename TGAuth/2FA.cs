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
        private void button1_Click(object sender, EventArgs e)
        {
            //создаём пустой список параметров для отправки на сервер
            List<IDictionary<string, string>> args = new List<IDictionary<string, string>>();
            //создаём пустой параметр
            IDictionary<string, string> arg = new Dictionary<string, string>();
            //заполняем логин
            arg["username"] = username;
            //заполняем код
            arg["code"] = textBox1.Text;
            //добавляем параметр в список
            args.Add(arg);
            //создаём сообщение
            JsonMsg msg = new JsonMsg(OperTypes.checkCode, args);

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
