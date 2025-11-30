using UnityEngine;

[CreateAssetMenu(fileName = "PartIndicator", menuName = "Scriptable Objects/PartIndicator")]
public class PartIndicator : ScriptableObject
{
    [field: SerializeField]
    public int PartId { get; private set; }
    [field: SerializeField]
    public GameObject GameObject { get; private set; }
}
