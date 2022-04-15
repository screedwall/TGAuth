namespace TGAuth
{
    public class Client
    {
        static public async Task<string> sendRequest(string hostname, int port, OperTypes path, IDictionary<string, string> args)
        {
            //проверяем настройки
            if (hostname == null || port == 0)
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
                    return await client.GetStringAsync($"http://{hostname}:{port}/{request}");
                } catch
                {
                    MessageBox.Show("Ошибка соединения с сервером", "Ошибка", MessageBoxButtons.OK);
                    return null;
                }
            }
        }
    }
}
