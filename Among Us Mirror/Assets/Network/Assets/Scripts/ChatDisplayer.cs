using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private List<string> messages = new();

    private void UpdateText()
    {
        this._text.text = "";
        foreach (var message in messages)
        {
            this._text.text += $"{message}\n";
        }
    }

    public void OnNewMessage(string msg)
    {
        Debug.Log(msg);
        messages.Add(msg);
        this.UpdateText();
    }
}