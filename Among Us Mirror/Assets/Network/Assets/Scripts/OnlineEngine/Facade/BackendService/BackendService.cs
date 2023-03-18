using OnlineEngine.Facade.BackendService.Friends;

namespace OnlineEngine.Facade.BackendService
{
    internal class BackendService : IBackendService
    {
        public IFriendsBackendService friendsBackendService() => new FriendsBackendService();
    }
}