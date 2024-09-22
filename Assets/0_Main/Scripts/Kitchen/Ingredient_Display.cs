using Emp37.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient_Display : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image image;

    [SerializeField] private Sprite sprite;

    [Button]
    private void Start()
    {
        title.text = name;
        image.sprite = sprite;
    }
}
