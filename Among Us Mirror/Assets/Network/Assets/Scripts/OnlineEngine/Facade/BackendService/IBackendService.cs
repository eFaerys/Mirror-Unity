using OnlineEngine.Facade.BackendService.Friends;

namespace OnlineEngine.Facade.BackendService
{
    internal interface IBackendService
    {
        IFriendsBackendService friendsBackendService();
    }
}