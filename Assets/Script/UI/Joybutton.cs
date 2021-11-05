using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joybutton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool m_bIsPressed = false;  
    
    public void OnPointerDown(PointerEventData eventData)
    {
        m_bIsPressed = true;
        Debug.Log("Pointer Down");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        m_bIsPressed = false;
        Debug.Log("Pointer Up");
    }

    public bool IsJoyPressed()
    {
        return m_bIsPressed;
    }


}
