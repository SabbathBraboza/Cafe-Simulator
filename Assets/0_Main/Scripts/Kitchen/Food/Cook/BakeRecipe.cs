using System.Collections;
using UnityEngine;

public class BakeRecipe : MonoBehaviour
{
    [SerializeField] private GameObject RecipeObject;
    [SerializeField] private Transform[] ProductPosition;
    [SerializeField] private GameObject Spawner;
    [SerializeField] private Waiter waiterRef;

    public void BuildBakesRecipes(Recipe recipe)
    {
        RecipeObject = recipe.productObject;

        int temp = Random.Range(0, ProductPosition.Length);
        if(RecipeObject != null)
        {
           waiterRef.ActiveSelf(true);
            var RecipeObjectSpawn = Instantiate(RecipeObject, ProductPosition[temp].position,Quaternion.identity , Spawner.transform);
            print("Recipe Object Spawned");
            StartCoroutine(ReadyToGo());
        }
        else
        {
            print("No Product Perfab Assigned");
        }
    }

    IEnumerator ReadyToGo()
    {
        yield return new WaitForSeconds(4f);
        waiterRef.SetNewRandomDestination();
        waiterRef.CurrentFoodObject(RecipeObject);
    }
}
