using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;
using System;

public class RoomSetup : MonoBehaviour {

	public Room myRoom;
	public Canvas roomCanvas;
	public Dropdown ThemeDropdown;
	int tIndex;
	public GameObject splinePath;
	public SplineAnchor curAnchor;
	bool settingPath;
	[SerializeField] Transform roomPropPanel;
	[SerializeField] HouseManager houseManager { get; }
	public GameObject propPanelTemplate;
	public bool overRoomPanel;
	public bool overInventoryPanel;

	public List<string> options = new List<string> ();
	// Use this for initialization
	void Start () {
		HideUI ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log (hit.collider.gameObject.name);
				if (hit.collider.tag == "Room") {
					myRoom = hit.collider.GetComponent<Room> ();
					GetThemeIndex ();
					ShowUI ();
					ThemeDropdown.value = GetThemeIndex ();
				}
				if (hit.collider.tag == "Door") {
					CreateRoomPath (hit.collider.transform.position);
					settingPath = true;
				}
			}
		}

		if (Input.GetMouseButtonUp (0) && settingPath) {
			settingPath = false;
		}
		if (settingPath) {			
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			worldPoint.z = worldPoint.y;
			curAnchor.Anchor.position = worldPoint;
		}
	}

	public void DragAnchor (Vector3 v)
	{
		curAnchor.transform.position = v;
	}

	public int GetThemeIndex ()
	{
		Themes t = myRoom.theme;
		tIndex = (int)t;
		return tIndex;
	}

	public void CreateRoomPath (Vector3 startPoint)
	{
		GameObject newSpline = Instantiate(splinePath, transform.position, Quaternion.identity);
		Spline sp = newSpline.GetComponent<Spline>();
		sp.Anchors [0].transform.position = startPoint;
		curAnchor = sp.Anchors [1];
	}

	public void Dropdown_IndexChanged (int index)
	{
		Themes s = (Themes)index;
		myRoom.theme = (Themes)index;
	}

	public void ShowUI ()
	{
		roomCanvas.gameObject.SetActive (true);

	}

	void UpdatePanel ()
	{
		int i = transform.childCount;
		for (int y = 0; y < i; y++) {
			Destroy (transform.GetChild (y).gameObject);
		}
		int row = 0;
		int column = 0;
		for (int x = 0; x < myRoom.props.Count; x++) {
			GameObject newPanel = Instantiate (propPanelTemplate, Vector3.zero, Quaternion.identity);
			DraggablePanel p = newPanel.GetComponent<DraggablePanel> ();
			p.ChangeText ();
			newPanel.transform.SetParent (roomPropPanel);
			column++;
			RectTransform panelTransform = newPanel.GetComponent<RectTransform> ();
			panelTransform.localPosition = new Vector3 (-110 + (60 * column), 85 - (60 * row), 0);
			if (x % 3 == 0) {
				row++;
				column = 0;
			}
		}
	}

	public void HideUI ()
	{
		roomCanvas.gameObject.SetActive (false);
		int x = 0; 
		x = roomPropPanel.childCount;
		for (int y = 0; y < x; y++) {
		}
		if (myRoom) {
			myRoom.ChangeTheme (myRoom.theme);
			myRoom.gameObject.name = myRoom.theme.ToString ();
		}
	}
}
