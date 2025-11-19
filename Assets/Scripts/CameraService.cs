using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraService: MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    public static CameraService Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            throw new Exception("More than one camera script");
        }
        Instance = this;
    }

    public bool GetMouseInput(LayerName layer, out RaycastHit hit)
    {
        hit = new();
        if (MouseIsOverUI()) return false;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        int layerMaskToHit = LayerMask.GetMask(layer.ToString());

        return Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskToHit);
    }

    private bool MouseIsOverUI()
    {
        int uiLayer = LayerMask.NameToLayer(LayerName.UI.ToString());

        PointerEventData eventData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> raycastResults = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventData, raycastResults);

        return raycastResults.Where(r => r.gameObject.layer == uiLayer).Count() > 0;
    }
}
