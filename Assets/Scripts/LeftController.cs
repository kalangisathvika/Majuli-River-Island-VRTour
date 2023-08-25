using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool active = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        active = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        active = false;
    }

    private void Update()
    {
        if (active && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fired Left");
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
    }
}
