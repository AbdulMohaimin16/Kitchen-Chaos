using UnityEngine;

public class GetKitchenObjectType : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectScriptableObject GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        
        this.kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a kitchen object!");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static GetKitchenObjectType SpawnKitchenObject(KitchenObjectScriptableObject kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        GameObject kitchenObjectGameObject = Instantiate(kitchenObjectSO.prefab);
        GetKitchenObjectType kitchenObject = kitchenObjectGameObject.GetComponent<GetKitchenObjectType>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }
}
