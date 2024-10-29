using UnityEngine;

public class ReciptDisplay : MonoBehaviour
{
    [SerializeField] private ReciptPerfab ReciptPerfabRef;
    [SerializeField] private RectTransform Content;

    public void DispalyRecipt(string Name,int Amount)
    {
        var SpawnRecipts = Instantiate(ReciptPerfabRef, Content);
        SpawnRecipts.ReciptsActive(name, Amount);
    }
}
