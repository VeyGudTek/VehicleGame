using System;
using System.Collections.Generic;
using UnityEngine;

public class PersistedPartData
{
    public Guid InstanceId { get; set; }
    public int PartId { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public List<Guid> Children { get; set; } = new();
}
