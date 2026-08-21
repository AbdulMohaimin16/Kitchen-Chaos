using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float movementSpeed = 10f;

    private bool isWalking;
   
   public PlayerInput playerInputScript;
    // Update is called once per frame
    private void Update()
    {
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float moveDistance = movementSpeed * Time.deltaTime;
        bool canMove;


        Vector2 inputMovementVector = playerInputScript.PlayerInputNormalized();

        Vector3 moveDirection = new Vector3(inputMovementVector.x, 0f, inputMovementVector.y);
        
        //canMove = ! Physics.Raycast(transform.position, moveDirection, playerRadius);
        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);

        if(canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        isWalking = moveDirection != Vector3.zero;
      

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);

    }

     public bool IsWalking()
    {
        return isWalking;
    }
    

}
