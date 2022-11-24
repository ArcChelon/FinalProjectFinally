using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private bool groundedPlayer;
   

    private PlayerInput playerInput;
    private InputAction upAction;
    private InputAction downAction;
    private InputAction jumpAction;

    [SerializeField] public float moveSpeed;
    

    [SerializeField] Transform endTargetMiddle;
    [SerializeField] Transform endTargetTop;
    [SerializeField] Transform endTargetBottom;
    private Transform currentEndTarget;

    private Vector3 playerVelocity;

    private float jumpSpeed = 1.0f;
    private bool jumpPressed = false;
    private float gravity = -9.81f;
    





    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        upAction = playerInput.actions["Up"];
        downAction = playerInput.actions["Down"];
        //jumpAction = playerInput.actions["Jump"];
        currentEndTarget = endTargetMiddle;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
        this.transform.position = Vector3.MoveTowards(transform.position, currentEndTarget.position, Time.deltaTime * moveSpeed);

        

        







    }

    private void Movement()
    {
        if (upAction.WasPressedThisFrame() && upAction.IsPressed())
        {
            if (transform.position.z <= 2f)
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            }


        }
        else if (downAction.WasPerformedThisFrame() && downAction.IsPressed())
        {
            if (transform.position.z >= -2)
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            }


        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TopZone"))
        {
           
            currentEndTarget = endTargetTop;
        }
        else if (other.CompareTag("MiddleZone"))
        {
            
            currentEndTarget = endTargetMiddle;
        }
        else if(other.CompareTag("BottomZone"))
        {
            
            currentEndTarget = endTargetBottom;
        }
        if(other.CompareTag("Shooter") || other.CompareTag("Runner"))
        {
            this.gameObject.GetComponent<PlayerHealth>().damagePlayer();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EndZone"))
        {
            other.GetComponent<EndZone>().levelChanger();
        }
    }
    
}
