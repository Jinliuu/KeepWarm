using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler{

    public IInventoryItem Item { get; set; }
    //reference the inventory item

    //Implement draghandler interface
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
		//Debug.Log ("The OnDrag from ItemDragHandler works");
        //Let the image in the inventory slot follow the mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
		//Debug.Log ("The OnEndDrag from ItemDragHandler works");
        //Reset the position of image to the parent when the drag is ended
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
