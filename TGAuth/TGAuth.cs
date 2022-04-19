using Newtonsoft.Json;

namespace TGAuth
{
    public partial class TGAuth : Form
    {
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

            var res = await Client.sendRequest(OperTypes.login, request);

            if (res != null)
            {
                var msg = JsonConvert.DeserializeObject<Msg<Response>>(res);
                //���� ������ ������ ��
                if (msg.status == Response.OK)
                {
                    //������������� �����
                    _2FA twoFactor = new _2FA(username_tb.Text);
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
                WriteToBot writeToBotForm = new WriteToBot(username_tb.Text, password_tb.Text);
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

