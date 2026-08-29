using System;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    public void Interact()
    {
        Debug.Log("Interact");
      
        GameObject kitchenObjectGameObject = Instantiate(kitchenObjectSO.prefab, counterTopPoint);;
        kitchenObjectGameObject.transform.localPosition = Vector3.zero;

        Debug.Log("Instantiated: " + kitchenObjectGameObject.GetComponent<GetKitchenObjectType>().GetKitchenObjectSO().objectName);
    }
}