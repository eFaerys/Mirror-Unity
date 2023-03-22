using Mirror;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void StartGameClicked()
    {
        NetworkManager.singleton.ServerChangeScene("Jeux");
        //NetworkServer.SendToAll("La game va commencer");
    }
}
