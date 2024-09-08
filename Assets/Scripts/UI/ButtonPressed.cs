using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool _buttonPressed;

    public void Start()
    {
        _buttonPressed = false;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _buttonPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        _buttonPressed = false;
    }
}
