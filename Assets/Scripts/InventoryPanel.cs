using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class InventoryPanel : MonoBehaviour {

	public List<Prop> availableProps = new List<Prop>();
	public GameObject panelItemTemplate;
	public Vector3 localPanelStartPosition;
	public float xOffset;
	public Vector3 hidePosition;
	public Vector3 showPosition;

	public void ShowPanel ()
	{
		Tween.Value (transform.localPosition, showPosition, HandlePositionTween, .5f, 0f, Tween.EaseInOut);
	}

	public void HidePanel ()
	{
		Tween.Value (transform.localPosition, hidePosition, HandlePositionTween, .5f, 0f, Tween.EaseInOut);
	}

	public void HandlePositionTween (Vector3 value)
	{
		transform.localPosition = value;
	}

	public void UpdateInventoryItemPosition ()
	{
		int children = transform.childCount;
	}
}
