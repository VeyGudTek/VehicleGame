using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField]
    private GameObject partIndicator;

    void Start()
    {
        InputService.Instance.RegisterLeftClickListener(OnLeftClick);
    }

    private void Update()
    {
        if (CameraService.Instance.GetMouseInput(LayerName.Build, out RaycastHit hit))
        {
            partIndicator.SetActive(true);
            partIndicator.transform.position = hit.point;
            partIndicator.transform.LookAt(hit.point + hit.normal);

            Debug.Log(hit.normal);
        }
        else
        {
            partIndicator.SetActive(false);
        }
    }

    private void OnLeftClick()
    {

    }
}
