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

        public Settings_t()
        {
            ip = "127.0.0.1";
            port = 8000;
        }
    }

    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            ip_tb.Text = TGAuth.settings.ip;
            port_tb.Text = TGAuth.settings.port.ToString();
        }
        //обработчик для кнопки сохранить
        private void save_btn_Click(object sender, EventArgs e)
        {
            TGAuth.settings.ip = ip_tb.Text;
            TGAuth.settings.port = Int32.Parse(port_tb.Text);
            Close();
        }
    }
}
