using System;
using UnityEngine;

public class VehicleRepository : MonoBehaviour
{
    public static VehicleRepository Instance { get; private set; }

    private StoredVehicleDataList DataList { get; set; }
    private const string FileName = "VehicleData";

    private void Awake()
    {
        SetSingleton();
        GetPersistedData();
    }

    private void SetSingleton()
    {
        if (Instance != null)
        {
            throw new Exception("Multiple Singletons: [Part Repository]");
        }
        Instance = this;
    }

    private void GetPersistedData()
    {
        DataList = DataAccessService.ReadData<StoredVehicleDataList>(FileName);
    }

    public void SaveVehicle(StoredVehicleData vehicleData, int index = -1)
    {
        if (DataList.VehicleData.Count <= index || index < 0)
        {
            DataList.VehicleData.Add(vehicleData);
        }
        else
        {
            DataList.VehicleData.Insert(index, vehicleData);
        }
        DataAccessService.WriteData(FileName, DataList);
    }
}
