using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartButtons : MonoBehaviour
{
    [SerializeField]
    private List<Button> PartButtonList = new List<Button>();
    [SerializeField] TMP_Text SelectedText;

    private void Start()
    {
        BindButtons();
    }

    private void BindButtons()
    {
        List<PartObject> partData = PartDataProvider.Instance.GetPartData();

        for (int i = 0; i < partData.Count; i++)
        {
            int localIndex = i;
            if (i > PartButtonList.Count)
            {
                break;
            }

            string partName = partData[localIndex].Name;
            PartButtonList[i].onClick.AddListener(() => OnButtonClick(partData[localIndex].PartId, partName));
            PartButtonList[i].GetComponentInChildren<TMP_Text>().text = partName;
        }
    }

    private void OnButtonClick(int partId, string name)
    {
        BuildIndicator.Instance.UpdateIndicator(partId);
        SelectedText.text = $"Selected: {name}";
    }
}
