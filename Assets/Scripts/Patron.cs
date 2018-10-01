using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour {

	HouseManager houseManager;
	Themes greatestFear;
	Room curRoom;
	int scared;
	public bool inCenterOfRoom;

	// Use this for initialization
	void Start () {
		int r = Random.Range (0, 20);
		greatestFear = (Themes)Random.Range (0, 20);
		houseManager = GameObject.Find ("House Manager").GetComponent<HouseManager> ();
		curRoom = houseManager.GetFirstRoom ();
		GetRoomCenterPoint ();
	}

	void GetRoomCenterPoint ()
	{
		Vector3 centerPoint = curRoom.transform.GetChild (1).GetComponent<Collider> ().bounds.center;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
