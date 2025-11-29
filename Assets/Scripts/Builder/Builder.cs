using System;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public static Builder Instance { get; private set; }

    [SerializeField]
    private GameObject Core;
    private PersistedPartData Root { get; set; } = new();

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
        InitializeRoot();
    }

    private void InitializeRoot()
    {
        Root.Id = 0;
        Root.Position = Core.transform.position;
        Root.Rotation = Core.transform.eulerAngles;
    }

    public void PlaceVehiclePart(GameObject parent, GameObject child, int partId)
    {
        GameObject newPart = Instantiate(child, child.transform.position, child.transform.rotation, parent.transform);
        newPart.layer = LayerMask.NameToLayer(LayerName.Build.ToString());
    }
}
