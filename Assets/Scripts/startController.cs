using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class startController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool activeStart = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        activeStart = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        activeStart = false;
    }

    private void Update()
    {
        if (activeStart && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fired Up for start button");
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
    }
}