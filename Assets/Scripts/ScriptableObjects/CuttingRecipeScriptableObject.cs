using UnityEngine;

[CreateAssetMenu(fileName = "CuttingRecipe", menuName = "ScriptableObjects/CuttingRecipeScriptableObject", order = 1)]
public class CuttingRecipeScriptableObject : ScriptableObject
{
    public KitchenObjectScriptableObject input;
    public KitchenObjectScriptableObject output;

    public int cuttingProgressMax;
}
