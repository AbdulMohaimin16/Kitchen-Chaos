using UnityEngine;

public class PlatesIconUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject platesKitchenObject;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        platesKitchenObject.OnIngredientAdded += PlatesKitchenObject_OnPlateCountChanged;
    }

    private void PlatesKitchenObject_OnPlateCountChanged(object sender, PlateKitchenObject.OnIngredientEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach (KitchenObjectScriptableObject kitchenObjectSO in platesKitchenObject.GetKitchenObjectSOList())
        {
            // Update the UI to show the ingredient represented by kitchenObjectSO
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }

}
