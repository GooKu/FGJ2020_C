using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private BearController bearController;

    public void OnPointerDown(PointerEventData eventData)
    {
        bearController.Pick();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bearController.PutDown();
    }
}
