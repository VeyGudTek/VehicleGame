using System.Collections;
using UnityEngine;

public class PartsMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform PartsMenuParent;
    [SerializeField]
    private bool IsOpen = true;

    private void Update()
    {
        UpdatePartsMenu();
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
        if (!IsOpen && PartsMenuParent.anchoredPosition.x > -MenuWidth / 2f)
        {
            newPosition.x -= slideSpeed;
            newPosition.x += (-MenuWidth / 2f - PartsMenuParent.anchoredPosition.x) * Time.deltaTime * 5f;
        }
        newPosition.x = Mathf.Clamp(newPosition.x, -MenuWidth / 2f, MenuWidth / 2f);

        PartsMenuParent.anchoredPosition = newPosition;
    }
}
