using System;
using System.Linq;
using UnityEngine;

public class BuildIndicator : MonoBehaviour
{
    public static BuildIndicator Instance { get; private set; }

    [field: SerializeField]
    private PartIndicatorList PartObjectDataList { get; set; }
    private int currentIndicatorPartId { get; set; } = 1;
    private GameObject Indicator { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            throw new Exception("Multiple Singletons: [Build Indicator]");
        }
        Instance = this;
    }

    private void Start()
    {
        InputService.Instance.RegisterLeftClickListener(OnLeftClick);

        IntantiateIndicator(currentIndicatorPartId);
    }

    private void IntantiateIndicator(int id)
    {
        GameObject indicatorToCreate = PartObjectDataList.Data.Where(p => p.PartId == id).First().GameObject;
        Indicator = Instantiate(indicatorToCreate, transform);
    }

    private void Update()
    {
        ShowIndicator();
    }

    private void ShowIndicator()
    {
        if (CameraService.Instance.GetMouseInput(LayerName.Build, out RaycastHit hit))
        {
            Indicator.SetActive(true);
            Indicator.transform.position = hit.point;
            Indicator.transform.LookAt(hit.point + hit.normal);
        }
        else
        {
            Indicator.SetActive(false);
        }
    }

    private void OnLeftClick()
    {
        if (CameraService.Instance.GetMouseInput(LayerName.Build, out RaycastHit hit))
        {
            Builder.Instance.PlaceVehiclePart(Indicator, currentIndicatorPartId);
        }
    }
}
