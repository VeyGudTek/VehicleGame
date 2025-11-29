using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PartObjectDataList", menuName = "Scriptable Objects/PartObjectDataList")]
public class PartObjectDataList : ScriptableObject
{
    [field: SerializeField]
    public List<PartObjectData> Data { get; private set; } = new();
}
