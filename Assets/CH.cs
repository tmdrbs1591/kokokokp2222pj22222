using UnityEngine;
using UnityEngine.UI;

public class CH : MonoBehaviour
{
    private Button button;
    private ColorBlock originalColors;

    void Start()
    {
        button = GetComponent<Button>();
        originalColors = button.colors; 
    }

    public void OnPointerEnter()
    {
        
        ColorBlock newColors = button.colors;
        newColors.normalColor = new Color(1f, 1f, 1f, 1f); 
        button.colors = newColors;
    }

    public void OnPointerExit()
    {
        
        button.colors = originalColors;
    }
}