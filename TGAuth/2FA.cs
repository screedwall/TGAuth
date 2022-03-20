namespace TGAuth
{
    public partial class _2FA : Form
    {
        string code;
        public _2FA(string code)
        {
            this.code = code;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == code) {
                this.Close();
                MessageBox.Show("Вы успешно вошли!", "LogIn", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Неверный код!", "Error", MessageBoxButtons.OK);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
