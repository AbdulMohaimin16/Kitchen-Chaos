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
             GetKitchenObjectType.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }  
    }

    
}
