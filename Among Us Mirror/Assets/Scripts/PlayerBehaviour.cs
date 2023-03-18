    using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 _movementInput;
    public float MoveSpeed = 2;
    [SerializeField] private TMP_Text pseudo = null;

    public Animator _animator;
    // Start is called before the first frame update

    private Camera _camera;
    void Start()
    {
        //if (isLocalPlayer)
        {
            _camera = Camera.main;
        }   
    }
    
    private void HandlePseudoChanged(string oldPseudo, string newPseudo)
    {
        pseudo.text = newPseudo;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isLocalPlayer) return;
        _movementInput = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
        _animator.SetBool("RunAnim", !Mathf.Approximately(_movementInput.magnitude, 1));
    }

    
    private void FixedUpdate()
    {
        //if (!isLocalPlayer) return;
    }

    private void LateUpdate()
    {
        //if (!isLocalPlayer || !_camera) return;
        _camera.transform.position = transform.position + 10 * Vector3.back;
    }
}
