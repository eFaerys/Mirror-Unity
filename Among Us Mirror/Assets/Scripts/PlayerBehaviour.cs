    using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
    using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerBehaviour : NetworkBehaviour
{
    private Vector2 _movementInput;
    public float MoveSpeed = 2;
    [SerializeField] private TMP_Text pseudo = null;
    [SerializeField] private Rigidbody2D rigidbody2D = null;
    [SerializeField] private Animator animator;
    [SyncVar(hook = nameof(HandlePseudoChanged))]
    string speudo = "Player";
    private Camera _camera;
    void Start()
    {
        if (isOwned)
        {
            _camera = Camera.main;
        }   
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = MoveSpeed * _movementInput;
        //if (!isLocalPlayer) return;
    }

    private void LateUpdate()
    {
        if (!isOwned || !_camera) return;
       _camera.transform.position = transform.position + 10 * Vector3.back;
    }
    
    #region Server

    [Command]
    private void CmdToMove()
    {
        _movementInput = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")

        );
        if (_movementInput.x > 0)
        {
            transform.localScale = Vector3.one;
        } else if (_movementInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
    [Server]
    public void SetPseudo(string newPseudo)
    {
        this.speudo = newPseudo;
    }
    
    #endregion

    #region Client
    [Client]
    
    private void HandlePseudoChanged(string oldPseudo, string newPseudo)
    {
        pseudo.text = newPseudo;
    }

    private void Update()
    {
        if (!isOwned) return;
        CmdToMove();
    }
    
    #endregion

}
