using UnityEngine;
using UnityEngine.EventSystems;

public class Clicking : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Controller.instance.GenerateDollars();
    }
}
