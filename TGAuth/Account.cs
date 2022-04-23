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

        //заполняемъ лейблы
        private void UpdateLabels()
        {
            access_token_label.Text = "access_token: " + Settings.settings.token.access_token;
            refresh_token_label.Text = "refresh_token: " + Settings.settings.token.refresh_token;
            refresh_time_label.Text = "refresh_time: " + Settings.settings.token.refresh_time.ToString();
        }

        //обновить токены
        private async void refresh_tokens_btn_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["refresh_token"] = Settings.settings.token.refresh_token;

            //отправка запроса на обновление токенов
            var res = await Client.sendRequest(OperTypes.refreshTokens, request);

            //если сервер прислал ответ
            if (res != null)
            {
                //распаковка сообщения из стоки в объект
                var msg = JsonConvert.DeserializeObject<Msg<Token>>(res);
                //если статус ответа ок
                if (msg.status == Response.OK)
                {
                    //обновляяем токены в памяти
                    Settings.settings.token = msg.data[0];
                }
                else
                {
                    Settings.settings.token.access_token = "Ошибка!";
                    Settings.settings.token.refresh_token = "Ошибка!";
                }
                //обновили токены на форме
                UpdateLabels();
            }
        }

        //проверить просрочен ли access_token
        private async void ping_btn_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["access_token"] = Settings.settings.token.access_token;

            //отправка запроса на годность access_token'а
            var res = await Client.sendRequest(OperTypes.ping, request);

            //если сервер прислал ответ
            if (res != null)
            {
                //распаковка сообщения из стоки в объект
                var msg = JsonConvert.DeserializeObject<Msg<Response>>(res);
                //если статус ответа ок
                if (msg.status == Response.OK)
                {
                    ping_result_label.Text = "Да " + msg.currentTime;
                }
                else
                {
                    ping_result_label.Text = "Нет";
                }
            }
        }
    }
}
