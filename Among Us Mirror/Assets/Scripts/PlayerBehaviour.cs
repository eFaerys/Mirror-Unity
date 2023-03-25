    using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
    using UnityEngine.InputSystem;

public class PlayerBehaviour : NetworkBehaviour
{
    private Vector2 _movementInput;
    public float MoveSpeed = 4;
    [SerializeField] private TMP_Text pseudo = null;
    Rigidbody myRB;
    Animator myAnim;
    Vector2 mousePositionInput;
    [SerializeField] InputAction MOUSE;
    [SerializeField] InputAction INTERACTION;
    [SerializeField] LayerMask interactLayer;

    // Start is called before the first frame update

    private Camera _camera;

    private void Awake()
    {
        INTERACTION.performed += Interact;
    }

    private void OnEnable()
    {
        INTERACTION.Enable();
    }

    private void OnDisable()
    {
        INTERACTION.Disable();
    }

    void Start()
    {
        //if (isLocalPlayer)
        myAnim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody>();
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
        mousePositionInput = MOUSE.ReadValue<Vector2>();
        //if (!isLocalPlayer) return;
        _movementInput = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
        myAnim.SetFloat("Speed", _movementInput.magnitude);
        // TODO: Trouver pouruquoi ce truc de merde marche pas 
//        Debug.Log(animator.parameters.GetEnumerator());
//        animator.SetBool("IsWalking", !Mathf.Approximately(_movementInput.magnitude, 0));

       if (_movementInput.x > 0)
       {
           transform.localScale = Vector3.one;
       } else if (_movementInput.x < 0)
       {
           transform.localScale = new Vector3(-1, 1, 1);
       }
    }

    
    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        myRB.velocity = MoveSpeed * _movementInput;
    }

    private void LateUpdate()
    {
        if (!isLocalPlayer || !_camera) return;
       _camera.transform.position = transform.position + 10 * Vector3.back;
    }

    void Interact(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Here");
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(mousePositionInput);
            if (Physics.Raycast(ray, out hit, interactLayer))
            {
                if (hit.transform.tag == "Interactable")
                {
                    if (!hit.transform.GetChild(0).gameObject.activeInHierarchy)
                        return;
                    AU_Interactable temp = hit.transform.GetComponent<AU_Interactable>();
                    Debug.Log("Minigame Launched");
                }
            }
        }
    }
}
