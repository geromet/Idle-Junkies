using UnityEngine;
using UnityEngine.EventSystems;
class MapMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float mouseZoomSpeed;
    [SerializeField] float touchZoomSpeed;    
    [SerializeField] float dragSpeed;
    [SerializeField] float touchDragSpeed;
    [SerializeField] Camera main;    
    [SerializeField] float maxZoom;
    [SerializeField] float minZoom;
    private Vector3 dragOrigin;
    private bool moving = false;

    public void Start()
    {

    }
    public void Update()
    {
        if (moving)
        {
            DragCamera();
            CheckZoom();
        }   
    }


    private void Zoom(float deltaMagnitudeDiff, float speed)
    {
        if ((deltaMagnitudeDiff * speed) + main.transform.position.z <= maxZoom && (deltaMagnitudeDiff * speed) + main.transform.position.z >= minZoom)
        {
            main.transform.Translate(0, 0, (deltaMagnitudeDiff * speed));
        }
            
    }

    private void CheckZoom()
    {
        Zoom(Input.GetAxis("Mouse ScrollWheel"), mouseZoomSpeed);
        if (Input.touchCount == 2)
        {
            Zoom(Vector2.Distance((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition), (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition)) - Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position), -touchZoomSpeed);
        }
    }

    private void DragCamera()   
    {
        if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }       
        if (!Input.GetMouseButton(0)) return;
        main.transform.Translate(-main.ScreenToViewportPoint(Input.mousePosition - dragOrigin).x * dragSpeed, -main.ScreenToViewportPoint(Input.mousePosition - dragOrigin).y * dragSpeed, 0, Space.World);
    }

   
    public void OnPointerEnter(PointerEventData eventData)
    {
        moving = true;

    }
    public void OnPointerExit(PointerEventData eventData)
        {
            moving = false;
        }
}    