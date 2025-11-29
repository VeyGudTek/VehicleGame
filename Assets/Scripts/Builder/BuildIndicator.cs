using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildIndicator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> vehicleParts = new List<GameObject>();
    private int currentIndex { get; set; } = 0;

    public static BuildIndicator Instance { get; private set; }
    public GameObject Indicator => vehicleParts[currentIndex];

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
        foreach (GameObject part in vehicleParts)
        {
            part.SetActive(false);
        }
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

            Debug.Log(hit.normal);
        }
        else
        {
            Indicator.SetActive(false);
        }
    }
}
