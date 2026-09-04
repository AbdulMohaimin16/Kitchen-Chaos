using UnityEngine;
using System;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; }


    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }
    
    public float movementSpeed = 10f;
    [SerializeField] private LayerMask countersLayerMask;


    [SerializeField] private BaseCounter selectedCounter;

     [SerializeField] private Transform kitchenObjectHoldPoint;
    private Vector3 lastInteractionPosition;
    private bool isWalking;
    private GetKitchenObjectType getKitchenObjectType;

   
   public PlayerInput playerInputScript;

   private void Awake()
    {
        if(Instance != null)
            Debug.LogError("There is more than one Player instance");

        Instance = this;
    }

   private void Start()
    {
        playerInputScript.OnInteractAction += PlayerInputScript_OnInteraction;
        playerInputScript.OnInteractAlternateAction += PlayerInputScript_OnInteractionAlternate;
    }

    private void PlayerInputScript_OnInteraction(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
            selectedCounter.Interact(this);   
    }
    private void PlayerInputScript_OnInteractionAlternate(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
            selectedCounter.InteractAlternate(this);   
    }
    // Update is called once per frame
    private void Update()
    {
        HandleMovement();
        HandleInteraction();

    }

     public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteraction()
    {
        float interactionDistance = 2f;
        Vector2 inputMovementVector = playerInputScript.PlayerInputNormalized();

        Vector3 moveDirection = new Vector3(inputMovementVector.x, 0f, inputMovementVector.y);

        if(moveDirection != Vector3.zero)
        {
            lastInteractionPosition = moveDirection;
        }   

        if(Physics.Raycast(transform.position, lastInteractionPosition, out RaycastHit raycastGameObjectHit, interactionDistance, countersLayerMask))
        {
            if(raycastGameObjectHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
        
    }

    private void HandleMovement()
    {
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float moveDistance = movementSpeed * Time.deltaTime;
        bool canMove;


        Vector2 inputMovementVector = playerInputScript.PlayerInputNormalized();

        Vector3 moveDirection = new Vector3(inputMovementVector.x, 0f, inputMovementVector.y);

        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);

        if(!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f).normalized;
            canMove = moveDirection.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);

            if(canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z).normalized;
                canMove = moveDirection.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);

                if(canMove)
                {
                    moveDirection = moveDirectionZ;
                }
            }
        } 

        if(canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        isWalking = moveDirection != Vector3.zero;
      

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);

        
    }
    
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        if (this.selectedCounter == selectedCounter)
            return;

        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

     public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(GetKitchenObjectType getKitchenObjectType)
    {
        this.getKitchenObjectType = getKitchenObjectType;
    }

    public GetKitchenObjectType GetKitchenObject()
    {
        return getKitchenObjectType;
    }

    public void ClearKitchenObject()
    {
        getKitchenObjectType = null;
    }

    public bool HasKitchenObject()
    {
        return getKitchenObjectType != null;
    }
}
