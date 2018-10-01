using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggablePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler{

	public Text myText;
	public Prop myProp;
	public RectTransform propsPanel;
	public HouseManager houseManager;
	void Start ()
	{
		myText.text = myProp.name;
		houseManager = GameObject.Find ("House Manager").GetComponent<HouseManager> ();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		GameObject houseManager = GameObject.Find ("House Manager");
		HouseManager HM = houseManager.GetComponent<HouseManager> ();
		HM.heldPanel = this;
	}

	public void ChangeText ()
	{
		myText.text = myProp.name;
	}

	public void OnDrag (PointerEventData eventData)
	{
		this.transform.position = eventData.position;
	}

	public void OnDrop (PointerEventData eventData)
	{
		if (!houseManager.roomSetup.overRoomPanel && !houseManager.roomSetup.overInventoryPanel) {
		}

		if (houseManager.heldPanel)
			houseManager.heldPanel = null;
	}
}
