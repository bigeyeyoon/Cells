using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfoPanel : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown (PointerEventData pointerEventData)
    {
        UIManager.Show<ItemDetailView>();
    }
    
}
