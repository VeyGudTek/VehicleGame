using System;
using UnityEngine;

public class BuildPart : MonoBehaviour
{
    public Guid InstanceId { get; private set; }
    public int PartId { get; private set; }

    public void Initialize(int id)
    {
        InstanceId = Guid.NewGuid();
        PartId = id;
    }
}
