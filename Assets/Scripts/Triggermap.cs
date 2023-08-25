using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Triggermap : MonoBehaviour
{ 
    public GameObject mapobj;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    public void OnTriggerMap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!mapobj.activeSelf)
            {
                float distance = 1f;
                Quaternion rotation = cam.transform.rotation;
                Matrix4x4 rotationMatrix = Matrix4x4.Rotate(rotation);
                Vector3 localForward = rotationMatrix.MultiplyVector(Vector3.forward);
                Vector3 position = localForward * distance;
                gameObject.transform.position = position;
                transform.rotation = cam.transform.rotation;
                mapobj.SetActive(true);
            }
            else if (mapobj.activeSelf)
            {
                mapobj.SetActive(false);
            }
        }
    }
}
