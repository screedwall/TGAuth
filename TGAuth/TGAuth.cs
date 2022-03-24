namespace TGAuth
{
    public partial class TGAuth : Form
    {
        public TGAuth()
        {
            InitializeComponent();
        }

        //обработчик кнопки "вход"
        private void login_btn_Click(object sender, EventArgs e)
        {
            //создаём пустой список параметров для отправки на сервер
            List<IDictionary<string, string>>  args = new List<IDictionary<string, string>>();
            //создаём пустой параметр
            IDictionary<string, string> arg = new Dictionary<string, string>();
            //заполняем логин
            arg["username"] = username_tb.Text.ToLower();
            //заполняем пароль
            arg["password"] = password_tb.Text;
            //добавляем параметр в список
            args.Add(arg);
            //создаём сообщение
            JsonMsg msg = new JsonMsg(OperTypes.login, args);

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
                    //инициализация формы
                    _2FA twoFactor = new _2FA(username_tb.Text.ToLower());
                    twoFactor.Show();
                }
                else
                {
                    MessageBox.Show("Такой пользователь не зарегистрирован!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        //обработчик кнопки "регистрация"
        private void button1_Click(object sender, EventArgs e)
        {
            //проверяем заполнены ли поля логин и пароль
            if (username_tb.TextLength == 0 || password_tb.TextLength == 0)
            {
                MessageBox.Show("Не заполнен логин или пароль", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                //инициализация формы
                WriteToBot writeToBotForm = new WriteToBot(username_tb.Text.ToLower(), password_tb.Text);
                writeToBotForm.Show();
            }
        }
    }
}

