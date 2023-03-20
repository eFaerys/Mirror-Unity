using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Enter");
        }
    }

    private void OnCollisionStay(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Btn")
        {
            Debug.Log("Stay");
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Btn")
        {
            Debug.Log("Exit");
        }
    }
}
