using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        if (conn.identity.TryGetComponent<PlayerBehaviour>(out var player))
        {
            var playerPseudo = $"Player{NetworkServer.connections.Count}";
            // player.SetPseudo(playerPseudo);
        }
    }
}