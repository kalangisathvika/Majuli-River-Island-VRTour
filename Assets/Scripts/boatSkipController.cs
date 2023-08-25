using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class boatSkipController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool activeBoatSkip = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        activeBoatSkip = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        activeBoatSkip = false;
    }

    private void Update()
    {
        if (activeBoatSkip && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fired Up for boat skip button");
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
    }
}
