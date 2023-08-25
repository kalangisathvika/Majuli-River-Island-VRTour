using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class introSkipController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool activeSkip = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        activeSkip = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        activeSkip = false;
    }

    private void Update()
    {
        if (activeSkip && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fired Up for skip button");
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
    }
}
