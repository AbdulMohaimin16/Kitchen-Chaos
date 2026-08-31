using UnityEngine;

public class GetKitchenObjectType : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptableObject kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectScriptableObject GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if(this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        
        this.clearCounter = clearCounter;

        if(clearCounter.HasKitchenObject())
        {
            Debug.LogError("ClearCounter already has a kitchen object!");
        }

        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
