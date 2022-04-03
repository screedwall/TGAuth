namespace TGAuth
{
    public partial class TGAuth : Form
    {
        static public Settings_t settings = new Settings_t();
        public TGAuth()
        {
            InitializeComponent();
        }

        //���������� ������ "����"
        private async void login_btn_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["username"] = username_tb.Text;
            request["password"] = password_tb.Text;

            var res = await Client.sendRequest(settings.ip, settings.port, OperTypes.login, request);

            if (res != null)
            {
                //���� ������ ������ ��
                if (res == Response.OK.ToString())
                {
                    //������������� �����
                    _2FA twoFactor = new _2FA(username_tb.Text, settings);
                    twoFactor.Show();
                }
                else
                {
                    MessageBox.Show("����� ������������ �� ���������������!", "������", MessageBoxButtons.OK);
                }
            }
        }

        //���������� ������ "�����������"
        private void button1_Click(object sender, EventArgs e)
        {
            //��������� ��������� �� ���� ����� � ������
            if (username_tb.TextLength == 0 || password_tb.TextLength == 0)
            {
                MessageBox.Show("�� �������� ����� ��� ������", "������", MessageBoxButtons.OK);
            }
            else
            {
                //������������� �����
                WriteToBot writeToBotForm = new WriteToBot(username_tb.Text, password_tb.Text, settings);
                writeToBotForm.Show();
            }
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.Show();
        }
    }
}

