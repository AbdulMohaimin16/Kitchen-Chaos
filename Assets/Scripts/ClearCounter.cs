using System;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    
    [SerializeField] private ClearCounter secondClearCounter;
    
    [SerializeField] private bool testing;

    private GetKitchenObjectType getkitchenObjectType;

    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if(getkitchenObjectType != null)
            {
                getkitchenObjectType.SetClearCounter(secondClearCounter);
            }
        }
    }

    public void Interact()
    {
      if(getkitchenObjectType == null)
        {
            GameObject kitchenObjectGameObject = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectGameObject.transform.GetComponent<GetKitchenObjectType>().SetClearCounter(this);
        }
        else
        {
            Debug.Log(getkitchenObjectType.GetClearCounter());
        }  
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(GetKitchenObjectType getKitchenObjectType)
    {
        this.getkitchenObjectType = getKitchenObjectType;
    }

    public GetKitchenObjectType GetKitchenObject()
    {
        return getkitchenObjectType;
    }

    public void ClearKitchenObject()
    {
        getkitchenObjectType = null;
    }

    public bool HasKitchenObject()
    {
        return getkitchenObjectType != null;
    }
}