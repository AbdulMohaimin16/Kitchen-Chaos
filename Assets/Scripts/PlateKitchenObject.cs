using UnityEngine;
using System.Collections.Generic;

public class PlateKitchenObject : GetKitchenObjectType
{

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
            return true;
        }
        return false;
    }

}
