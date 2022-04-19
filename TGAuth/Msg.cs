namespace TGAuth
{
    class Msg<T>
    {
        public Response status;
        public T[] data;
        public Msg(T obj, Response status)
        {
            this.status = status;
            data = new T[1] { obj };
        }

        public Msg(Response status)
        {
            this.status = status;
            data = new T[0];
        }

        public Msg() {}
    }
}
