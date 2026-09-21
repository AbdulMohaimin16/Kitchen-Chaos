using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            // There is no KitchenObject here
            if(player.HasKitchenObject())
            {
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying anything

            }
        }
        else
        {
            // There is a KitchenObject here
            if (player.HasKitchenObject())
            {
                // There is a KitchenObject here
            }
            else
            {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}