using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseManager : MonoBehaviour {
	[SerializeField] GameObject roomPrefab;
	[SerializeField] int xSpaceBetweenRooms;
	[SerializeField] int ySpaceBetweenRooms;
	[SerializeField] Text moneyText;
	public DraggablePanel heldPanel;
	public RoomSetup roomSetup;
	public enum houseSize
	{
		small,
		medium,
		large,
		huge,
	}

	public houseSize HouseSize;


	int availableCash;
	List<Prop> allProps = new List<Prop>();
	List<Prop> unusedProps = new List<Prop>();
	List<Room> rooms = new List<Room>();

	void Awake ()
	{
		roomSetup = GetComponent<RoomSetup> ();
		if (!roomSetup)
			Debug.LogError ("I can't find the room setup tool.");
		switch (HouseSize) {
		case houseSize.small:
			InitializeHouse (4);
			break;
		case houseSize.medium:
			InitializeHouse (6);
			break;
		case houseSize.large:
			InitializeHouse (8);
			break;
		case houseSize.huge:
			InitializeHouse (12);
			break;
		}
		UpdateCash ();
	}

	public Room GetCurrentRoom ()
	{
		return roomSetup.myRoom;
	}

	void UpdateCash ()
	{
		moneyText.text = "$" + availableCash;
	}

	void Update ()
	{
		if (Input.mousePosition.y >= Screen.height * .95f) {
			Camera.main.transform.position += new Vector3 (0, 0, 5) * Time.deltaTime;
		} else if (Input.mousePosition.y <= Screen.height * .05f) {
			Camera.main.transform.position += new Vector3 (0, 0, -5) * Time.deltaTime;
		}

		if (Input.mousePosition.x >= Screen.width * .95f) {
			Camera.main.transform.position += new Vector3 (5, 0, 0) * Time.deltaTime;
		} else if (Input.mousePosition.x <= Screen.width * 0.05f) {
			Camera.main.transform.position += new Vector3 (-5, 0, 0) * Time.deltaTime;
		}

		Vector2 d = Input.mouseScrollDelta;
		Camera.main.fieldOfView -= d.y;
	}

	void InitializeHouse (int roomx)
	{
		CreateFirstRoom ();
		string lastDir;
		for (int x = 0; x < roomx - 1; x++) {
			int R = GetRandomNumber (0, 10);
			if (R < 6 ) {
				CreateSideRoom ();
				lastDir = "Side";
			} else {
				CreateForwardRoom ();
				lastDir = "Front";
			}
		}
	}

	public Room GetFirstRoom ()
	{
		return rooms [0];
	}

	int GetRandomNumber (int min, int max)
	{
		int r = Random.Range (min, max);
		return (int)r;
	}

	void CreateFirstRoom ()
	{
		GameObject firstRoom = Instantiate (roomPrefab, Vector3.zero, Quaternion.identity);
		Room fR = firstRoom.GetComponent<Room> ();
		rooms.Add (fR);
	}

	void CreateSideRoom ()
	{
		int i = Random.Range (0, rooms.Count);
		Collider lastCreatedRoom = rooms [i].GetComponent<Collider> ();
		int n = Random.Range (-1, 1);
		if (n == 0)
			n = 1;
		Vector3 spot = new Vector3 (lastCreatedRoom.transform.position.x + (xSpaceBetweenRooms * n), 0, rooms [i].transform.position.z);
		bool canPlace = CheckRoomSpace (spot);
		if (canPlace) {
			GameObject SideRoom = Instantiate (roomPrefab, spot, Quaternion.identity);
			Room r = SideRoom.GetComponent<Room> ();
			rooms.Add (r);
		} else {
			/*spot = new Vector3 (lastCreatedRoom.transform.position.x + (xSpaceBetweenRooms * -n), 0, rooms [rooms.Count - 1].transform.position.z);
			GameObject sideRoom = Instantiate (roomPrefab, spot, Quaternion.identity);
			Room r = sideRoom.GetComponent<Room> ();
			rooms.Add (r);*/
			CreateForwardRoom ();
		}
	}

	bool CheckRoomSpace (Vector3 spot)
	{
		List<bool> checks = new List<bool> ();
		for (int x = 0; x < rooms.Count; x++) {
			if (rooms [x].transform.position == spot)
				checks.Add (false);
			else {
				checks.Add (true);
			}
		}
		if (checks.Contains (false))
			return false;
		else
			return true;
	}

	void CreateForwardRoom ()
	{
		int i = Random.Range (0, rooms.Count);
		Collider lastCreatedRoom = rooms [i].GetComponent<Collider> ();
		int n = Random.Range (-1, 1);
		if (n == 0)
			n = 1;
		Vector3 spot = new Vector3 (rooms [i].transform.position.x, 0, lastCreatedRoom.transform.position.z + ySpaceBetweenRooms);
		bool canPlace = CheckRoomSpace (spot);
		if (canPlace) {
			GameObject SideRoom = Instantiate (roomPrefab, spot, Quaternion.identity);
			Room r = SideRoom.GetComponent<Room> ();
			rooms.Add (r);
		} else {
			CreateSideRoom ();
		}
	}
}
