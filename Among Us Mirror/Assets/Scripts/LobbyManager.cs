using Mirror;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void StartGameClicked()
    {
        Debug.Log("Ca a cliqué");
        NetworkManager.singleton.ServerChangeScene("Jeux");
        //NetworkServer.SendToAll("La game va commencer");
    }
}
