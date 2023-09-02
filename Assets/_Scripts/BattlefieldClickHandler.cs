using UnityEngine;
using UnityEngine.EventSystems;

public class BattlefieldClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        EventsManager.instance.TouchBattlefield(Camera.main.ScreenToWorldPoint(eventData.position));
    }
}
