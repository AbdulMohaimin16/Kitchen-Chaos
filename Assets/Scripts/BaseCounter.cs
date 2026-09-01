using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint;

    private GetKitchenObjectType getKitchenObjectType;
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter.Interact();");
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
