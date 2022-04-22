namespace TGAuth
{
    public class Client
    {
        //метод для отправки запроса на сервер
        static public async Task<string> sendRequest(OperTypes path, IDictionary<string, string> args)
        {
            //проверяем настройки
            if (String.IsNullOrEmpty(Settings.settings.ip) || Settings.settings.port == 0)
            {
                MessageBox.Show("Задайте параметры соединения в настройках!", "Ошибка", MessageBoxButtons.OK);
                return null;
            }
            //конструктор строки запроса
            string request = $"{path}?";
            foreach (var el in args)
            {
                request += $"{el.Key}={el.Value}&";
            }

            using (var client = new HttpClient())
            {
                try
                {
                    //отправка запроса на сервер
                    return await client.GetStringAsync($"http://{Settings.settings.ip}:{Settings.settings.port}/{request}");
                } catch
                {
                    MessageBox.Show("Ошибка соединения с сервером", "Ошибка", MessageBoxButtons.OK);
                    return null;
                }
            }
        }
    }
}
