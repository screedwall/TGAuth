using Newtonsoft.Json;

namespace TGAuth
{
    public class JsonMsg
    {
        public OperTypes operType;
        public Response status;
        public List<IDictionary<string, string>> args;
        public JsonMsg(OperTypes operType, List<IDictionary<string, string>> args)
        {
            this.operType = operType;
            this.args = args;
            this.status = Response.ERROR;
        }
        public JsonMsg()
        {
            this.status = Response.ERROR;
        }

        //конвертация из объекта в строку
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        //конвертация из строки в объект
        public static JsonMsg ToObj(string json)
        {
            return JsonConvert.DeserializeObject<JsonMsg>(json);
        }
    }
}
