using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace TGAuth
{
    public class Client
    {
        TcpClient client;
        public Client(string hostname, int port)
        {
            try
            {
                //пытаемся установить соединение с сервером
                client = new TcpClient(hostname, port);
            } catch
            {
                //Ошибка соединения с сервером
                client = null;
                MessageBox.Show("Ошибка соединения с сервером", "Ошибка", MessageBoxButtons.OK);
            }
        }

        public JsonMsg send(string msg)
        {
            if (client == null)
            {
                return null;
            }
            //получаем поток
            NetworkStream nwStream = client.GetStream();
            //преобразуем сообщения в байты в кодировке UTF8
            byte[] bytesToSend = Encoding.UTF8.GetBytes(msg);

            //отправляем в поток байты
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //ожидание ответа с сервера
            JsonMsg response = readData(nwStream);

            //закрываем соединение 
            client.Close();

            return response;
        }

        JsonMsg readData(NetworkStream nwStream)
        {
            int i;
            //считываем по 256 байт из потока
            Byte[] bytes = new Byte[256];
            while ((i = nwStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                //преобразование байтов в строку
                string data = Encoding.UTF8.GetString(bytes, 0, i);
                //восстановление объекта из строки
                JsonMsg response = JsonConvert.DeserializeObject<JsonMsg>(data);
                return response;
            }
            return null;
        }
    }
}
