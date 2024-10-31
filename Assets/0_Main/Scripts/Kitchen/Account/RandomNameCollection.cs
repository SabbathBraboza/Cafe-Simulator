using UnityEngine;

public class RandomNameCollection : MonoBehaviour
{
    public string[] Names;
    public string CurrentNames;

    public void GetName()
    {
        int randomName = Random.Range(0, Names.Length);
        CurrentNames = Names[randomName];
    }
}
