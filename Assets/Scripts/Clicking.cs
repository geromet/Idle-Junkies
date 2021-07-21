using UnityEngine;
using UnityEngine.EventSystems;
public class Clicking : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool clicked = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (clicked == false)
        {
            Controller.instance.GenerateDollars();
            clicked = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        clicked = false;
    }
}
