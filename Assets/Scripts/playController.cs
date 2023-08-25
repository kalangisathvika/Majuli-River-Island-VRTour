using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playController : MonoBehaviour
{
    public static bool activePlay = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        activePlay = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        activePlay = false;
    }

    private void Update()
    {
        if (activePlay && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fired Up for play button");
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
    }
}
