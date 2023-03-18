using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ChatHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> OnReceivedMessage;

    [SerializeField] private string ip = "127.0.0.1";
    [SerializeField] private int port = 7778;

    [SerializeField] private TMP_Text _text;
    
    private IPEndPoint endpoint = null;
    private UdpClient client = null;

    private void Start()
    {
        Application.runInBackground = true;
        IPAddress.TryParse(ip, out var iPAddress);
        endpoint = new IPEndPoint(iPAddress, port);

        client = new UdpClient();
        client.Connect(endpoint);

        client.BeginReceive(new AsyncCallback(ReceiveUDPMessage), client);
    }

    public void SendUDPMessage(string msg)
    {
        var dgram = Encoding.UTF8.GetBytes(msg);
        client.Send(dgram, dgram.Length);
        OnReceivedMessage?.Invoke(msg);
    }

    private void ReceiveUDPMessage(IAsyncResult res)
    {
        var dgram = client.EndReceive(res, ref endpoint);
        var data = Encoding.UTF8.GetString(dgram);
        
        client.BeginReceive(new AsyncCallback(ReceiveUDPMessage), client);
    }
}