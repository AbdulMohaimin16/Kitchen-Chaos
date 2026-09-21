using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }

    public event EventHandler OnCut;

    [SerializeField] private CuttingRecipeScriptableObject[] cuttingRecipeSOArray;

    private int cuttingProgress;

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
                    
                    cuttingProgress = 0;

                    CuttingRecipeScriptableObject cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                    });
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
            cuttingProgress++;
            
            OnCut?.Invoke(this, EventArgs.Empty);
            
            CuttingRecipeScriptableObject cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
            });

            if ( cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
            {
                // There is a KitchenObject here
                KitchenObjectScriptableObject outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

                GetKitchenObject().DestroySelf();

                GetKitchenObjectType.SpawnKitchenObject(outputKitchenObjectSO, this);
            }
        }
    }


    private bool HasRecipeWithInput(KitchenObjectScriptableObject inputKitchemObjectSO)
    {
        CuttingRecipeScriptableObject cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchemObjectSO);
        return cuttingRecipeSO != null;
        
    }
    private KitchenObjectScriptableObject GetOutputForInput(KitchenObjectScriptableObject inputKitchenObjectSO)
    {
        CuttingRecipeScriptableObject cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if(cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private CuttingRecipeScriptableObject GetCuttingRecipeSOWithInput(KitchenObjectScriptableObject inputKitchenObjectSO)
    {
        foreach (CuttingRecipeScriptableObject cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO;
            }
        }

        return null;
    }

}
