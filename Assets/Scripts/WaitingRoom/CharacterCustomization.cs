using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    [SerializeField] Color[] allColors;

    public void SetColor(int colorIndex)
    {
        ChangeColor.changeColor.SetColor(allColors[colorIndex]);
    }
}