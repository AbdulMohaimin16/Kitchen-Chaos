using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class PlateKitchenObject : GetKitchenObjectType
{
    public event EventHandler<OnIngredientEventArgs> OnIngredientAdded;
    public class OnIngredientEventArgs : EventArgs
    {
        public KitchenObjectScriptableObject kitchenObjectSO;
    }


    [SerializeField] private List<KitchenObjectScriptableObject> validKitchenObjectSO;
    private List<KitchenObjectScriptableObject> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectScriptableObject>();
    }

    public bool TryAddIngredient(KitchenObjectScriptableObject kitchenObjectSO)
    {
        if (!validKitchenObjectSO.Contains(kitchenObjectSO))
        {
            return false;
        }
        if (!kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });
            return true;
        }
        return false;
    }

}
