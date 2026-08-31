using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetKitchenObjectFollowTransform();
    public void SetKitchenObject(GetKitchenObjectType getKitchenObjectType);

    public GetKitchenObjectType GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();
}
