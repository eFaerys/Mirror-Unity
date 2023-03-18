namespace OnlineEngine.ErrorHandler
{
    public enum ErrorCode
    {
        NOT_FOUND = 404
    }

    class OnlineEngineError
    {
        // Online pure
        OnlineEngineError(int statusCode)
        {
        }

        string GetMessage()
        {
            return "";
        }
    }

    public interface IErrorHandler
    {
        // 
    }
}