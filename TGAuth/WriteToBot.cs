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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/AmerkhanovaBot") { UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<IDictionary<string, string>> args = new List<IDictionary<string, string>>();
            IDictionary<string, string> arg = new Dictionary<string, string>();
            arg["username"] = username;
            arg["password"] = password;
            arg["chatId"] = chatId_tb.Text;
            args.Add(arg);
            JsonMsg msg = new JsonMsg(OperTypes.register, args);

            Client client = new Client("localhost", 80);
            JsonMsg res = client.send(msg.ToJson());

            if (res != null)
            {
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