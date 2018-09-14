using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler,IPointerDownHandler{
    public bool finalDestination = true; 
    private Vector3 mouseOffset;
    private Vector3 initialPosition;
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;    
        mouseOffset = transform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!finalDestination) {
            transform.position = initialPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       Debug.Log("Down");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BackgroundClicked() {
        Debug.Log("ClickBG");
    }
}
