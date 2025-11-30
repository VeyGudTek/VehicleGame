using System;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public static Builder Instance { get; private set; }

    [field: SerializeField]
    private Transform PartsParent { get; set; }


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

    }

    public void PlaceVehiclePart(GameObject child, int partId)
    {
        GameObject newPartObject = Instantiate(child, child.transform.position, child.transform.rotation, PartsParent);
        newPartObject.layer = LayerMask.NameToLayer(LayerName.Build.ToString());

        BuildPart newPartComonent = newPartObject.AddComponent<BuildPart>();
        newPartComonent.Initialize(partId);
    }
}
