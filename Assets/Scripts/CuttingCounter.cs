using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectScriptableObject cuttingkitchenObjectSO;

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

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {
            // There is a KitchenObject here
            GetKitchenObject().DestroySelf();

            GetKitchenObjectType.SpawnKitchenObject(cuttingkitchenObjectSO, this);
            //GameObject kitchenObjectGameObject = Instantiate(cuttingkitchenObjectSO.prefab);
            //kitchenObjectGameObject.transform.GetComponent<GetKitchenObjectType>().SetKitchenObjectParent(this);
        }
    }
}
