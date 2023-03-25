using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    GameObject hightlight;

    // Start is called before the first frame update

    void OnEnable()
    {
        hightlight = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hightlight.SetActive(true);
        }
    }
    
    private void OnTriggerEnterExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hightlight.SetActive(false);
        }
    }

    public void PlayMiniGame()
    {
        miniGame.SetActive(true);
    }
}
