using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PartObjectList", menuName = "Scriptable Objects/PartObjectList")]
public class PartObjectList : ScriptableObject
{
    [field: SerializeField]
    public List<PartObject> Data { get; private set; } = new();
}
