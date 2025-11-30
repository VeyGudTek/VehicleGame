using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PartIndicatorList", menuName = "Scriptable Objects/PartIndicatorList")]
public class PartIndicatorList : ScriptableObject
{
    [field: SerializeField]
    public List<PartIndicator> Data { get; private set; } = new();
}
