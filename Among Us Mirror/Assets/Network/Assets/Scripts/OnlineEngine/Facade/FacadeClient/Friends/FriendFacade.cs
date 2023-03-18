using System.Collections.Generic;

namespace OnlineEngine.Facade.FacadeClient.Friends
{
    public class FriendFacade : IFriendFacade
    {
        public List<object> GetFriends()
        {
            var bs = new BackendService.BackendService();
            bs.friendsBackendService().HttpRequest_GetFriends();

            return new List<object>();
        }
    }
}