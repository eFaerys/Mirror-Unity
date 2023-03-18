namespace OnlineEngine.EventHandler
{
    public interface IEventHanlder
    {
        void OnDisconnect();
        void OnConnected();
    }
}