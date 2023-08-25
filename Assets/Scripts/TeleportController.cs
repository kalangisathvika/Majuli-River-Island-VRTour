using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeleportController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool[] active;
    private float scaleFactor = 1.4f;
    private RectTransform rectTransform;
    private Vector3 defaultScale;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultScale = rectTransform.localScale;
    }

    private Vector2 originalSize;
    private void Start()
    {
        active = new bool[8];
        for(int i=0; i<8; i++)
        {
            active[i] = false;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = defaultScale * scaleFactor;
        string curTag = gameObject.tag;
        active[int.Parse(curTag)] = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = defaultScale;
        string curTag = gameObject.tag;
        active[int.Parse(curTag)] = false;
    }

    private void Update()
    {
        string curTag = gameObject.tag;
        if (active[int.Parse(curTag)] && Input.GetButtonDown("Fire2"))
        {
            rectTransform.localScale = defaultScale;
            active[int.Parse(curTag)] = false;
            Debug.Log("Teleported to " + int.Parse(curTag));
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
    }
}
