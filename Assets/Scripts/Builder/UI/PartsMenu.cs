using System.Collections;
using UnityEngine;

public class PartsMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform PartsMenuParent;
    [SerializeField]
    private RectTransform ToggleButton;
    private bool IsOpen = true;

    private void Update()
    {
        UpdatePartsMenu();
    }

    public void OnMenuToggle()
    {
        IsOpen = !IsOpen;
    }

    private void UpdatePartsMenu()
    {
        float MenuWidth = PartsMenuParent.sizeDelta.x;
        Vector2 newPosition = PartsMenuParent.anchoredPosition;
        float slideSpeed = 10f * Time.deltaTime;

        if (IsOpen && PartsMenuParent.anchoredPosition.x < MenuWidth / 2f)
        {
            newPosition.x += slideSpeed;
            newPosition.x += (MenuWidth / 2f - PartsMenuParent.anchoredPosition.x) * Time.deltaTime * 5f;
        }
        float toggleButtonWidth = ToggleButton.sizeDelta.x;
        if (!IsOpen && PartsMenuParent.anchoredPosition.x > (-MenuWidth / 2f) + toggleButtonWidth)
        {
            newPosition.x -= slideSpeed;
            newPosition.x += (-MenuWidth / 2f - PartsMenuParent.anchoredPosition.x + toggleButtonWidth) * Time.deltaTime * 5f;
        }
        newPosition.x = Mathf.Clamp(newPosition.x, -MenuWidth / 2f, MenuWidth / 2f);

        PartsMenuParent.anchoredPosition = newPosition;
    }
}
