using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGAuth
{
    public struct Settings_t
    {
        public string ip;
        public int port;
        public Token token;

        public Settings_t()
        {
            ip = "127.0.0.1";
            port = 8000;
            token = new Token();
        }
    }

    public partial class Settings : Form
    {
        // Настройки клиента
        static public Settings_t settings = new Settings_t();

        public Settings()
        {
            InitializeComponent();
            ip_tb.Text = settings.ip;
            port_tb.Text = settings.port.ToString();
        }
        //обработчик для кнопки сохранить
        private void save_btn_Click(object sender, EventArgs e)
        {
            settings.ip = ip_tb.Text;
            settings.port = Int32.Parse(port_tb.Text);
            Close();
        }
    }
}
