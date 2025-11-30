using System;
using System.Linq;
using UnityEngine;

public class BuildIndicator : MonoBehaviour
{
    public static BuildIndicator Instance { get; private set; }
    private int currentIndicatorPartId { get; set; } = -1;
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
    }

    public void UpdateIndicator(int partId)
    {
        GameObject oldIndicator = Indicator;
        currentIndicatorPartId = partId;

        GameObject indicatorToCreate = PartDataProvider.Instance.GetPartData()
            .Where(p => p.PartId == currentIndicatorPartId)
            .First().GameObject;
        Indicator = Instantiate(indicatorToCreate, transform);

        if (oldIndicator != null)
        {
            Destroy(oldIndicator);
        }
    }

    private void Update()
    {
        ShowIndicator();
    }

    private void ShowIndicator()
    {
        if (Indicator == null) return;

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
        if (Indicator == null) return;

        if (CameraService.Instance.GetMouseInput(LayerName.Build, out RaycastHit hit))
        {
            Builder.Instance.PlaceVehiclePart(Indicator, currentIndicatorPartId);
        }
    }
}
