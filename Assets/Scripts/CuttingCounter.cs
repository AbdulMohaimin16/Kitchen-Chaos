using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeScriptableObject[] cuttingRecipeSOArray;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            // There is no KitchenObject here
            if(player.HasKitchenObject())
            {
                // Player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    // Player is carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
        if(HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            // There is a KitchenObject here
            KitchenObjectScriptableObject outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().DestroySelf();

            GetKitchenObjectType.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }


    private bool HasRecipeWithInput(KitchenObjectScriptableObject inputKitchemObjectSO)
    {
        foreach (CuttingRecipeScriptableObject cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchemObjectSO)
            {
                return true;
            }
        }
        return false;
    }
    private KitchenObjectScriptableObject GetOutputForInput(KitchenObjectScriptableObject inputKitchenObjectSO)
    {
        foreach (CuttingRecipeScriptableObject cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }

        return null;
    }
}
