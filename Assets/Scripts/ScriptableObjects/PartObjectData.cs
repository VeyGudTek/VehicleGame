using UnityEngine;

[CreateAssetMenu(fileName = "PartObjectData", menuName = "Scriptable Objects/PartObjectData")]
public class PartObjectData : ScriptableObject
{
    [field: SerializeField]
    public int Id { get; private set; }
    [field: SerializeField]
    public PartType Type { get; private set; }
    [field: SerializeField]
    public GameObject GameObject { get; private set; }
}
