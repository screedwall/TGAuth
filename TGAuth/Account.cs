using Newtonsoft.Json;

namespace TGAuth
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            access_token_label.Text = "access_token: " + Settings.settings.token.access_token;
            refresh_token_label.Text = "refresh_token: " + Settings.settings.token.refresh_token;
            refresh_time_label.Text = "refresh_time: " + Settings.settings.token.refresh_time.ToString();
        }

        private async void refresh_tokens_btn_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["refresh_token"] = Settings.settings.token.refresh_token;

            var res = await Client.sendRequest(OperTypes.refreshTokens, request);

            //если сервер прислал ответ
            if (res != null)
            {
                var msg = JsonConvert.DeserializeObject<Msg<Token>>(res);
                //если статус ответа ок
                if (msg.status == Response.OK)
                {
                    Settings.settings.token.access_token = msg.data[0].access_token;
                    Settings.settings.token.refresh_token = msg.data[0].refresh_token;
                    Settings.settings.token.refresh_time = msg.data[0].refresh_time;
                }
                else
                {
                    Settings.settings.token.access_token = "Ошибка!";
                    Settings.settings.token.refresh_token = "Ошибка!";
                }
                UpdateLabels();
            }
        }

        private async void ping_btn_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["access_token"] = Settings.settings.token.access_token;

            var res = await Client.sendRequest(OperTypes.ping, request);

            //если сервер прислал ответ
            if (res != null)
            {
                var msg = JsonConvert.DeserializeObject<Msg<Response>>(res);
                //если статус ответа ок
                if (msg.status == Response.OK)
                {
                    ping_result_label.Text = "Пинг прошел";
                }
                else
                {
                    ping_result_label.Text = "Пинг не прошел";
                }
            }
        }
    }
}
