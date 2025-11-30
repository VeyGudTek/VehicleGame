using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoredPartData
{
    public string InstanceId;
    public int PartId;
    public Vector3 Position;
    public Vector3 Rotation;
    public List<string> NeighborInstanceId;
}
