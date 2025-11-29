using UnityEngine;

public class Axle : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    private void Start()
    {
        InputService.Instance.RegisterLeftClickListener(OnLeftClick, fix: true);
    }

    private void OnLeftClick()
    {
        _rigidBody.AddTorque(new Vector3(10f, 0f, 0f));
    }
}
