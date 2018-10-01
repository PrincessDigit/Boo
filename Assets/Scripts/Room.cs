using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	public Themes theme;
	public int budgetedAmount;
	public int grandTotal;
	public List<Prop> props = new List<Prop>();
	public Transform entrance;
	public Transform exit;
	public List<GameObject> walls = new List<GameObject>();


	Renderer rend;
	public void Start ()
	{
		rend = GetComponent<Renderer> ();
		ChangeWallColor (GlobalTextures.Instance.GetInvisibleWall ());
	}

	public void ChangeTheme (Themes newTheme)
	{
		rend.material = GlobalTextures.Instance.GetMyMaterial (newTheme);
	}

	public void ChangeWallColor (Material newMat)
	{
		for (int x = 0; x < walls.Count; x++) {
			Renderer wallRend = walls [x].GetComponent<Renderer> ();
			wallRend.material = newMat;
		}
	}
}
