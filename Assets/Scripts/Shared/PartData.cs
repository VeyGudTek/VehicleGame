using UnityEngine;

public enum PartType
{
    Body,
    Axle,
    Thruster
}

public class PartData
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public PartType Type { get; set; }
}