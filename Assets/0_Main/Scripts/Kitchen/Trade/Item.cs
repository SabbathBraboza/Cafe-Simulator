using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Button Pervious;
    [SerializeField] private Button Next;
    [SerializeField] private TMP_Text CurrentText;

    [SerializeField] private readonly int value;

    public int Value
    {
        get => value;
        set => value = Mathf.Clamp(value, 1, 10);
    }


}
