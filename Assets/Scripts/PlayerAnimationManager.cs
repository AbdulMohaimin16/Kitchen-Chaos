using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private const string IS_Walking = "IsWalking";
    
    [SerializeField] private Animator playerAnimator;

    [SerializeField] private Player playerScript;

    void Awake()
    {
        playerAnimator = GetComponent<Animator>();

        playerScript.GetComponentInParent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetBool(IS_Walking, playerScript.IsWalking());
    }

  
}
