using System;
using System.Collections.Generic;
using UnityEngine;

public class PartDataProvider : MonoBehaviour
{
    public static PartDataProvider Instance { get; private set; }
    [field: SerializeField]
    private PartObjectList PartsList { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            throw new Exception("Multiple Singletons: [Build Indicator]");
        }
        Instance = this;
    }

    public List<PartObject> GetPartData()
    {
        return PartsList.Data;
    }
}
