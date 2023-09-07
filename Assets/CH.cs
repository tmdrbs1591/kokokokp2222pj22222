using UnityEngine;
using UnityEngine.UI;

public class CH : MonoBehaviour
{
    private Button button;
    private ColorBlock originalColors; // ���� ��ư ����

    void Start()
    {
        button = GetComponent<Button>();
        originalColors = button.colors; // ���� �� ���� ��ư ���� �� ����
    }

    public void OnPointerEnter()
    {
        // ���콺�� ������ �� ��ư ������ �����մϴ�.
        ColorBlock newColors = button.colors;
        newColors.normalColor = new Color(1f, 1f, 1f, 1f); // ���� ���� ���� ����
        button.colors = newColors;
    }

    public void OnPointerExit()
    {
        // ���콺�� ���� �� ���� ��ư �������� �ǵ����ϴ�.
        button.colors = originalColors;
    }
}