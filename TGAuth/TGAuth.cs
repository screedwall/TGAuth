using System.Data.SqlClient;

namespace TGAuth
{
    public partial class TGAuth : Form
    {
        Bot bot = new Bot();
        DBase db = new DBase();
        public TGAuth()
        {
            InitializeComponent();
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            if (username_tb.TextLength == 0 || password_tb.TextLength == 0)
            {
                MessageBox.Show("�� �������� ����� ��� ������", "������", MessageBoxButtons.OK);
                return;
            }

            List<IDictionary<string, string>> sqlResponse = db.Select(String.Format("SELECT * FROM users WHERE username='{0}' AND password='{1}'", username_tb.Text.ToLower(), password_tb.Text));

            if (sqlResponse.Count > 0)
            {
                for (int j = 0; j < sqlResponse.Count; j++)
                {
                    var row = sqlResponse[j];
                    //���������� telegram id ����� ������������
                    int telegram_id = Int32.Parse(row["telegram_id"]);
                    //���������� 6 ������� ��������� ���
                    var rand = new Random();
                    var code = rand.Next(999999).ToString("D6");
                    //���������� ������� ����� � ������� SQL
                    DateTime dateTime = DateTime.Now;
                    string sqlFormattedDate = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");

                    //���������� ��� � �� ��� ����� ������������
                    db.Exec(String.Format("UPDATE codes " +
                                         "SET code={0}, date='{1}' " +
                                         "WHERE user_id={2}", code, sqlFormattedDate, row["Id"]));
                    //���������� ��� � ��������
                    bot.SendMsg(telegram_id, String.Format("������, {0}! ���� ��� ��� �����: {1}", username_tb.Text.ToLower(), code));

                    _2FA twoFactor = new _2FA(username_tb.Text.ToLower(), db);
                    twoFactor.Show();
                }
            } else
            {
                MessageBox.Show("����� ������������ �� ���������������!", "������", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username_tb.TextLength == 0 || password_tb.TextLength == 0)
            {
                MessageBox.Show("�� �������� ����� ��� ������", "������", MessageBoxButtons.OK);
                return;
            }

            //������ � �� � ������������� ������������ � ����� �������
            List<IDictionary<string, string>> sqlResponse = db.Select(String.Format("SELECT * FROM users WHERE username='{0}'", username_tb.Text.ToLower()));
            //���� ����� ������������ � ����� ������� ����������, �� ������� ������
            if (sqlResponse.Count > 0)
            {
                MessageBox.Show("����� ������������ ��� ���������������!", "������", MessageBoxButtons.OK);
            } else
            {
                WriteToBot writeToBotForm = new WriteToBot(username_tb.Text.ToLower(), password_tb.Text, db);
                writeToBotForm.Show();
            }
        }
    }
}

