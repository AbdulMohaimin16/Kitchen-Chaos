using UnityEngine;

[CreateAssetMenu(fileName = "KitchenObject", menuName = "ScriptableObjects/KitchenObject")]
public class KitchenObjectScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    public string objectName;
}
