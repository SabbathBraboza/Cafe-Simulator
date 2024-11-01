using Emp37.Utility;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    [Header("GameObject:")]
    [SerializeField] private Recipe[] RecipesRef;
    [SerializeField] private GameObject[] NotInteract;

    [Space(5f)]
    [Header("RectTransform:")]
    [SerializeField] private RectTransform Content;

    [Space(5f)]
    [SerializeField] private Order OrderRef;
    [SerializeField] internal TimeSystem TimeSystemRef;
    [SerializeField] private RandomNameCollection RandomNamesRef;
    [SerializeField] private OrderVerification OrderVerRef;

    private void Start()
    {
        RecipesRef = Resources.LoadAll<Recipe>("Recipe");
        NotInteract = new GameObject[4];
        OnGenerateRandomRecipes();
    }

    [Button]
    public void OnGenerateRandomRecipes()
    {
        for(int i = Content.childCount -1; i>=0;i--)
        {
            var Context = Content.GetChild(i).gameObject;
            Destroy(Context);
        }

        for(int i = 0; i<4;i++)
        {
            int Index = i;   
            //Pick Random Recipe
            int RandomIndex = Random.Range(0, RecipesRef.Length);
            Recipe CurrentOrder = RecipesRef[RandomIndex];
            RandomNamesRef.GetName();

            //Instantiate and Display The recipe
            var Order = Instantiate(OrderRef, Content);
            Order.ProductDisplayAs(CurrentOrder, RandomNamesRef.CurrentNames, CurrentOrder.OrderMinutes, CurrentOrder.OrderSeconds, Index, this);
            NotInteract[Index] = Order.NotInteractable;
        }
    }

    [Button]
    public void NewOrder()
    {
        int emptySlot = 0;
        for (int i = 0; i < NotInteract.Length; i++)
        {
            if (NotInteract[i] == null)
            {
                emptySlot = i;
                break;
            }
        }

        int RandomIndex = Random.Range(0, RecipesRef.Length);
        Recipe CurrentOrder = RecipesRef[RandomIndex];
        RandomNamesRef.GetName();
        var OrderDisplay = Instantiate(OrderRef, Content);
        OrderDisplay.ProductDisplayAs(CurrentOrder, RandomNamesRef.CurrentNames, CurrentOrder.OrderMinutes, CurrentOrder.OrderSeconds, emptySlot, this);
        NotInteract[emptySlot] = OrderDisplay.NotInteractable;
        ReActiveInteract();
    }

    public void ReActiveInteract()
    {
        for(int i = 0;i<NotInteract.Length;i++)
        {
            NotInteract[i].SetActive(false);
        }
    }

    public void OrderNotInteract(int Notuse)
    {
        for(int i = 0;i<NotInteract.Length;i++)
        {
            if(i == Notuse)
            {
                NotInteract[i].SetActive(false);
            }
            else
            {
                NotInteract[i].SetActive(true);
            }
        }

    }

    public void ClearOrderTrash(int RemoveIndex) => NotInteract[RemoveIndex] = null;

}
