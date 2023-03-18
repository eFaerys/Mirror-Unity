using System;
using UnityEngine;
using UnityEngine.Events;

public class Renamer : MonoBehaviour
{
    private event Action<string> OnMouseDownOnCube;
    private UnityAction<Vector3> onMouseDownOnCubeUnityAction;
    [SerializeField] private UnityEvent onMouseDownOnCubeUnityEvent;

    private void Start()
    {
        this.OnMouseDownOnCube += RenameGameObject;
        this.onMouseDownOnCubeUnityAction += MoveGameObject;
    }

    private void OnDestroy()
    {
        this.OnMouseDownOnCube -= RenameGameObject;
        this.onMouseDownOnCubeUnityAction -= MoveGameObject;
    }

    private void RenameGameObject(string name)
    {
        this.gameObject.name = name;
    }

    private void MoveGameObject(Vector3 v)
    {
        this.gameObject.transform.position = v;
    }


    private void OnMouseDown()
    {
        this.OnMouseDownOnCube?.Invoke("coucou");
        this.onMouseDownOnCubeUnityAction?.Invoke(new Vector3(10, 0, 10));
        this.onMouseDownOnCubeUnityEvent?.Invoke();
    }
}