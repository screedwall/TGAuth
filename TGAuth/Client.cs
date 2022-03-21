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
            client = new TcpClient(hostname, port);
        }

        public JsonMsg send(string msg)
        {
            //---data to send to the server---
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = Encoding.UTF8.GetBytes(msg);

            //---send the text---
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            JsonMsg response = readData(nwStream);

            client.Close();

            return response;
        }

        JsonMsg readData(NetworkStream nwStream)
        {
            int i;
            Byte[] bytes = new Byte[256];
            while ((i = nwStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                string data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                JsonMsg response = JsonConvert.DeserializeObject<JsonMsg>(data);
                return response;
            }
            return new JsonMsg();
        }
    }
}
