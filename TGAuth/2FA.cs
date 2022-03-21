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

        private void button1_Click(object sender, EventArgs e)
        {
            List<IDictionary<string, string>> args = new List<IDictionary<string, string>>();
            IDictionary<string, string> arg = new Dictionary<string, string>();
            arg["username"] = username;
            arg["code"] = textBox1.Text;
            args.Add(arg);
            JsonMsg msg = new JsonMsg(OperTypes.checkCode, args);

            Client client = new Client("localhost", 80);
            JsonMsg res = client.send(msg.ToJson());

            if (res != null)
            {
                if (res.status == Response.OK)
                {
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
