using UnityEngine;
using UnityEngine.UI;

public class CH : MonoBehaviour
{
    private Button button;
    private ColorBlock originalColors; // 기존 버튼 색상

    void Start()
    {
        button = GetComponent<Button>();
        originalColors = button.colors; // 시작 시 기존 버튼 색상 값 저장
    }

    public void OnPointerEnter()
    {
        // 마우스가 오버될 때 버튼 색상을 변경합니다.
        ColorBlock newColors = button.colors;
        newColors.normalColor = new Color(1f, 1f, 1f, 1f); // 보통 상태 색상 변경
        button.colors = newColors;
    }

    public void OnPointerExit()
    {
        // 마우스가 나갈 때 기존 버튼 색상으로 되돌립니다.
        button.colors = originalColors;
    }
}