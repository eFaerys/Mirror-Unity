namespace OnlineEngine.Facade.BackendService.Friends
{
    internal class FriendsBackendService: IFriendsBackendService
    {
        public object HttpRequest_GetFriends()
        {
            var d = new HttpRequest_GetFriendsEpic();
            return d;
        }
    }
}