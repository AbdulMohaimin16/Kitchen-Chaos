using UnityEngine;

public class GetKitchenObjectType : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;

    public KitchenObjectScriptableObject GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
}
