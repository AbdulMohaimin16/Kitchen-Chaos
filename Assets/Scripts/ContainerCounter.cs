using UnityEngine;
using System;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;


    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(Player player)
    {
      if(!player.HasKitchenObject())
        {
            // Player is not carrying anything 
            GameObject kitchenObjectGameObject = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectGameObject.transform.GetComponent<GetKitchenObjectType>().SetKitchenObjectParent(player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }  
    }

    
}
