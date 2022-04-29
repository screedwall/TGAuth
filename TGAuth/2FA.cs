namespace TGAuth
{
    public partial class _2FA : Form
    {
        DBase db;
        string username;
        public _2FA(string username, DBase db)
        {
            InitializeComponent();
            this.username = username;
            this.db = db;
        }
        //обработчик события кнопки "проверить"
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Не заполнен код", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            //запрос на поиск кода в БД
            List<IDictionary<string, string>> sqlResponse = db.Select(String.Format("SELECT * " +
                                                              "FROM codes " +
                                                              "INNER JOIN users " +
                                                              "ON codes.user_id = users.id " +
                                                              "WHERE users.username = '{0}' " +
                                                              "AND codes.code = {1}", username, textBox1.Text));
            //если код введен не правильно
            if (sqlResponse.Count == 0)
            {
                MessageBox.Show("Неверный код!", "Error", MessageBoxButtons.OK);
            }
            else
            {
                this.Close();
                MessageBox.Show("Вы успешно вошли!", "LogIn", MessageBoxButtons.OK);
            }
        }
    }
}
