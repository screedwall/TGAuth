namespace TGAuth
{
    class Msg<T>
    {
        public Response status;
        public DateTime currentTime;
        public T[] data;
        public Msg(T obj, Response status)
        {
            this.status = status;
            this.currentTime = DateTime.Now;
            data = new T[1] { obj };
        }

        public Msg(Response status)
        {
            this.status = status;
            this.currentTime = DateTime.Now;
            data = new T[0];
        }

        public Msg() { }
    }
}
