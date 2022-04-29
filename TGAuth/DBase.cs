using System.Data.SqlClient; //чтобы подключиться к БД SQL

namespace TGAuth
{
    public class DBase
    {
        SqlConnection db_conn;
        public DBase()
        {
            //устанавливаем подключение к БД
            db_conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tgauth;Integrated Security=True");
        }

        //метод для выборки данных
        public List<IDictionary<string, string>> Select(string query)
        {
            //подготавливаем запрос к выполнению
            SqlCommand queryCmd = new SqlCommand(query, db_conn);
            //открываем соединение
            queryCmd.Connection.Open();
            //выполняем запрос
            SqlDataReader reader = queryCmd.ExecuteReader();
            //создаём переменную для ответа
            List<IDictionary<string, string>> response = new List<IDictionary<string, string>>();
            //построчно считываем ответ
            while(reader.Read())
            {
                IDictionary<string, string> el = new Dictionary<string, string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    el[reader.GetName(i)] = reader[i].ToString();
                }
                response.Add(el);
            }
            //закрываем соединение
            queryCmd.Connection.Close();
            return response;
        }

        //метод для выполнения запроса
        public void Exec(string query)
        {
            //подготавливаем запрос к выполнению
            SqlCommand queryCmd = new SqlCommand(query, db_conn);
            //открываем соединение
            queryCmd.Connection.Open();
            //выполняем запрос
            queryCmd.ExecuteNonQuery();
            //закрываем соединение
            queryCmd.Connection.Close();
        }
    }
}
