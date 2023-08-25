using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pauseController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool activePause = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        activePause = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        activePause = false;
    }

    private void Update()
    {
        if (activePause && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fired Up for pause button");
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
    }
}
