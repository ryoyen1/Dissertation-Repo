using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public bool CanMove {get;  set;} = true;
    //Check if player is sprinting
    private bool isSprinting => Sprinting && Input.GetKey(sprintkey);
    private bool isJump => characterController.isGrounded && Input.GetKey(jumpkey) ;
    private bool isCrouch => Input.GetKey(crouchkey) && !duringCrouching && characterController.isGrounded;
    [Header("Booleans")]
    [SerializeField] private bool Sprinting = true;
    [SerializeField] private bool Jumping = true;
    [SerializeField] private bool Crouching = true;
    [SerializeField] private bool Bobbing = true;
    [SerializeField] private bool Interaction = true;

    [Header("Keys")]
    [SerializeField] private KeyCode sprintkey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpkey = KeyCode.Space;
    [SerializeField] private KeyCode crouchkey = KeyCode.C;
    [SerializeField] private KeyCode interactkey = KeyCode.Mouse0;

    [Header("Movement")]
    [SerializeField] private float walkingSpeed = 3.0f;
    [SerializeField] private float runningSpeed = 8.0f;
    [SerializeField] private float crouchSpeed = 1.5f;
    [SerializeField] private float gravity = 30.0f;
    [SerializeField] private float jumpPower = 8.0f;

    [Header("Crouching")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standHeight = 2f;
    [SerializeField] private float timetoCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0,0.5f,0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0,0,0);
    private bool isCrouching;
    private bool duringCrouching;

    [Header("Bobbing")]
    [SerializeField] private float BobbingWhileWalk = 10f;
    [SerializeField] private float BobbingAmntWhileWalk = 0.05f;
    [SerializeField] private float BobbingWhileSprint = 14f;
    [SerializeField] private float BobbingAmntWhileSprint = 0.11f;
    [SerializeField] private float BobbingWhileCrouch = 6f;
    [SerializeField] private float BobbingAmntWhileCrouch = 0.01f;
    private float defaultYPos = 0f;
    private float timer;

    [Header("Interact")]
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactionLayer = default;
    private Interact currentInteract;
    
    [Header("Camera Look")]
    [SerializeField, Range(1,10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1,10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1,180)] private float upperLock = 80.0f;
    [SerializeField, Range(1,180)] private float lowerLock = 80.0f;

    private Camera playerCam;
    private CharacterController characterController;

    private Vector3 moveDirec;
    private Vector2 currentInput;

    private float rotationX = 0;

    public static FirstPerson instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //Get Component from the player component
        playerCam = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        //When not moving, camera goes back to default position
        defaultYPos = playerCam.transform.localPosition.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove)
        {
            HandleMovement();
            HandleMouse();
            if(Jumping)
            {
                HandleJump();
            }

            if(Crouching)
            {
                HandleCrouch();
            }   
            if(Bobbing)
            {
                HandleBobbing();
            }
            if(Interaction)
            {
                CheckInteraction();
                HandleInteractionInput();
            }
            ApplyMovement();
        }
    }

//----------MOVEMENT----------
    private void HandleMovement()
    {
        currentInput = new Vector2((isCrouching ? crouchSpeed : isSprinting ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical"),
                                    (isCrouching ? crouchSpeed : isSprinting ? runningSpeed : walkingSpeed)* Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirec.y;
        moveDirec = (transform.TransformDirection(Vector3.forward) * currentInput.x)+ (transform.TransformDirection(Vector3.right) * currentInput.y); 
        moveDirec.y = moveDirectionY;
    }

    private void HandleMouse()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        //Disables camera to turn 360 degrees
        rotationX = Mathf.Clamp(rotationX, -upperLock, lowerLock);
        //Apply it to the camera Up and Down look
        playerCam.transform.localRotation = Quaternion.Euler(rotationX,0,0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void ApplyMovement()
    {
        if(!characterController.isGrounded)
        {
            moveDirec.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirec * Time.deltaTime);
    }

//------------JUMP------------
    private void HandleJump()
    {
        if(isJump)
        {
            moveDirec.y = jumpPower;
        }
    }
//------------CROUCH------------
    private void HandleCrouch()
    {
        if(isCrouch)
        {
            StartCoroutine(CrouchStand());
        }
    }

    private IEnumerator CrouchStand()
    {
        //Check if there is an object above player
        if(isCrouching && Physics.Raycast(playerCam.transform.position, Vector3.up, 1f))
        {
            yield break;
        }

        duringCrouching = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = characterController.center;

        while(timeElapsed < timetoCrouch)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timetoCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timetoCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        characterController.height = targetHeight;
        characterController.center = targetCenter;

        //Toggle crouch
        isCrouching = !isCrouching;

        duringCrouching = false;
    }
//------------BOBBING------------
    private void HandleBobbing()
    {
        if(!characterController.isGrounded) return;
        //To get a value that is positive
        if(Mathf.Abs(moveDirec.x) > 0.1f || Mathf.Abs(moveDirec.z) > 0.1f)
        {
            timer += Time.deltaTime * (isCrouching ? BobbingWhileCrouch 
            : isSprinting ? BobbingWhileSprint : BobbingWhileWalk);

            playerCam.transform.localPosition = new Vector3
            (playerCam.transform.localPosition.x, defaultYPos + Mathf.Sin(timer)*
            (isCrouching ? BobbingAmntWhileCrouch : isSprinting
             ? BobbingAmntWhileSprint : BobbingAmntWhileWalk));
        }
    }
//------------INTERACTION------------
    private void CheckInteraction()
    {
        //Raycast to check for object
        if(Physics.Raycast(playerCam.ViewportPointToRay(interactionRayPoint),
         out RaycastHit hit, interactionDistance))
        {
            //if its on layer 6 and there is no Interactable object raycasted
            if(hit.collider.gameObject.layer == 6 && (currentInteract == null 
            || hit.collider.gameObject.GetInstanceID() != currentInteract.GetInstanceID()))
            {
                //Infer the object to currentInteract
                hit.collider.TryGetComponent(out currentInteract);

                if(currentInteract == true)
                {
                    currentInteract.OnFocus();
                }
            }
        }
        //If Raycast does not see an object
        else if(currentInteract)
        {
            currentInteract.OnLoseFocus();
            currentInteract = null;
        }

    }
    private void HandleInteractionInput()
    {
        //if left mouse and current interact is not null (If Object of interactable is found)
        if(Input.GetKeyDown(interactkey) && currentInteract != null 
        && Physics.Raycast(playerCam.ViewportPointToRay(interactionRayPoint), 
        out RaycastHit hit, interactionDistance, interactionLayer))
        {
            currentInteract.OnInteract();
        }
    }
}
