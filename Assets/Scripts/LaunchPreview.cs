using UnityEngine;


public class LaunchPreview : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3      _dragStartPoint;


    private void Awake()
    {
        this._lineRenderer = GetComponent<LineRenderer>();

    }   // Awake()


    public void SetStartPoint(Vector3 worldPoint)
    {
        this._dragStartPoint = worldPoint;
        this._lineRenderer.SetPosition(0, this._dragStartPoint);

    }   // SetStartPoint()


    public void SetEndPoint(Vector3 worldPoint)
    {
        Vector3 pointOffset = worldPoint  - this._dragStartPoint;
        Vector3 endPoint    = pointOffset + transform.position;

        this._lineRenderer.SetPosition(1, endPoint);

    }   // SetEndPoint()


}   // class LaunchPreview