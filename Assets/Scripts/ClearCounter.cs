using System;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private GetKitchenObjectType getKitchenObjectType;

    public void Interact(Player player)
    {
      if(getKitchenObjectType == null)
        {
            GameObject kitchenObjectGameObject = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectGameObject.transform.GetComponent<GetKitchenObjectType>().SetKitchenObjectParent(this);
        }
        else
        {
            getKitchenObjectType.SetKitchenObjectParent(player);
        }  
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
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