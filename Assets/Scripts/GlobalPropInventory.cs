using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class GlobalPropInventory : Singleton<GlobalPropInventory> {

	public List<Prop> props = new List<Prop>();

	public Dictionary<string, Prop> gameProps = new Dictionary<string, Prop>();

	void Start ()
	{
		for (int x = 0; x < props.Count; x++) {
			gameProps.Add (props [x].name, props [x]);
		}
	}

	public Prop GetProp (string propName)
	{
		return gameProps [propName];
	}

}
