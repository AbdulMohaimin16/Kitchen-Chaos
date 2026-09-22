using UnityEngine;

[CreateAssetMenu(fileName = "FryingRecipe", menuName = "ScriptableObjects/FryingRecipeScriptableObject", order = 1)]
public class FryingRecipeScriptableObject : ScriptableObject
{
    public KitchenObjectScriptableObject input;
    public KitchenObjectScriptableObject output;

    public float fryingTimerMax;
}
