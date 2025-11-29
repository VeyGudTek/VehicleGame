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
        InputService.Instance.RegisterNextClickListeners(NextIndicator);
        InputService.Instance.RegisterPreviousClickListners(PreviousIndicator);

        foreach (GameObject part in vehicleParts)
        {
            part.SetActive(false);
        }
    }

    private void NextIndicator()
    {
        vehicleParts[currentIndex].SetActive(false);
        currentIndex++;

        if (currentIndex == vehicleParts.Count)
        {
            currentIndex = 0;
        }
    }

    private void PreviousIndicator()
    {
        vehicleParts[currentIndex].SetActive(false);
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = vehicleParts.Count - 1;
        }
    }
}
