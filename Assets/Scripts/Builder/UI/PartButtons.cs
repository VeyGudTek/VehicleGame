using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartButtons : MonoBehaviour
{
    [SerializeField]
    private List<Button> PartButtonList = new List<Button>();

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

            PartButtonList[i].onClick.AddListener(() => BuildIndicator.Instance.UpdateIndicator(partData[localIndex].PartId));
            PartButtonList[i].GetComponentInChildren<TMP_Text>().text = partData[localIndex].Name;
        }
    }
}
