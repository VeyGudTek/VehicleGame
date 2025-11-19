using UnityEngine;

public class Builder : MonoBehaviour
{
    private void Update()
    {
        ShowIndicator();
    }

    private void ShowIndicator()
    {
        GameObject indicator = BuildIndicator.Instance.Indicator;

        if (CameraService.Instance.GetMouseInput(LayerName.Build, out RaycastHit hit))
        {
            indicator.SetActive(true);
            indicator.transform.position = hit.point;
            indicator.transform.LookAt(hit.point + hit.normal);

            Debug.Log(hit.normal);
        }
        else
        {
            indicator.SetActive(false);
        }
    }
}
