using UnityEngine;

public class BakeRecipe : MonoBehaviour
{
    [SerializeField] private GameObject RecipeObject;
    [SerializeField] private Transform[] ProductPosition;
    [SerializeField] private GameObject Spawner;

    public void BuildBakesRecipes(Recipe recipe)
    {
        //RecipeObject = recipe.ProductPerfab;

        int temp = Random.Range(0, ProductPosition.Length);
        if(RecipeObject != null)
        {
            var RecipeObjectSpawn = Instantiate(RecipeObject, ProductPosition[temp].position,Quaternion.identity , Spawner.transform);
            print("Recipe Object Spawned");
        }
        else
        {
            print("No Product Perfab Assigned");
        }
    }
}
