using System;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;

    public override void Interact(Player player)
    {
        Debug.Log("Will be implementing interaction with clear counter");
    }
}