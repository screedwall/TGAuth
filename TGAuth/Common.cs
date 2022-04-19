namespace TGAuth
{
    //типы операций
    public enum OperTypes
    {
        login,
        register,
        checkCode,
        refreshTokens,
        ping
    }

    //коды ответа
    public enum Response
    {
        OK,
        ERROR
    }
}
