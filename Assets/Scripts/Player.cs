using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float movementSpeed = 10f;

    private bool isWalking;
   
   public PlayerInput playerInputScript;
    // Update is called once per frame
    private void Update()
    {

        Vector2 inputMovementVector = playerInputScript.PlayerInputNormalized();

        Vector3 moveDirection = new Vector3(inputMovementVector.x, 0f, inputMovementVector.y);

        transform.position += moveDirection * movementSpeed * Time.deltaTime;

    
        isWalking = moveDirection != Vector3.zero;
      

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);

    }

     public bool IsWalking()
    {
        return isWalking;
    }
    

}
