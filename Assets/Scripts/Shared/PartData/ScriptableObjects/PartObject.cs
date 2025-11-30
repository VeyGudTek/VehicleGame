using UnityEngine;

[CreateAssetMenu(fileName = "PartObject", menuName = "Scriptable Objects/PartObject")]
public class PartObject : ScriptableObject
{
    [field: SerializeField]
    public int PartId { get; private set; }
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public GameObject GameObject { get; private set; }
}
