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
        Debug.Log("addforce");
        _rigidBody.AddRelativeTorque(new Vector3(10f, 10f, 10f));
    }
}
