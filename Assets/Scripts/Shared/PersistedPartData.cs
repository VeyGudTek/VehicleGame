using System.Collections.Generic;
using UnityEngine;

public enum PartType
{
    Core,
    Body,
    Axle,
    Thruster
}

public class PersistedPartData
{
    public int Id { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public PartType Type { get; set; }
    public List<PersistedPartData> Children { get; set; } = new();
}
