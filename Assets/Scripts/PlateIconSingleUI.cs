using UnityEngine;
using UnityEngine.UI;

public class PlateIconSingleUI : MonoBehaviour
{
    [SerializeField] private Image image;


    public void SetKitchenObjectSO(KitchenObjectScriptableObject kitchenObjectSO)
    {
        // Set the icon image based on the kitchenObjectSO
        // For example, you can set the sprite of an Image component here

        image.sprite = kitchenObjectSO.sprite; // Assuming kitchenObjectSO has an icon property
    }
}
