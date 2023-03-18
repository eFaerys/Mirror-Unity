using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MyBomb : MonoBehaviour
{
    private Renderer _renderer = null;
    public UnityEvent OnExplosion;
    public event Action<string> OnExplosionScream;

    private void Start()
    {
        this._renderer = GetComponent<Renderer>();

        Debug.Log("Bomb created.");
        StartCoroutine(PrepareToExplode());
        Debug.Log("Bomb armed.");
    }

    private IEnumerator PrepareToExplode()
    {
        yield return new WaitForSeconds(3);

        this._renderer.material.color = Color.red;
        this.OnExplosion?.Invoke();
        this.OnExplosionScream?.Invoke("COUCOU");
        yield return new WaitForSeconds(2);

        Debug.Log("Boom !");
        Destroy(gameObject);
    }
}