using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient_Display : MonoBehaviour
{
      [SerializeField] private TextMeshProUGUI title;
     

     private void Start()
      {
            title.text = name;
            
      }
}
