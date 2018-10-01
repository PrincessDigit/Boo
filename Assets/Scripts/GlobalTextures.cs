using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class GlobalTextures : Singleton<GlobalTextures> {
	
	public Material tileFloor;
	public Material woodFloor;
	public Material hospitalFloor;
	public Material steelFloor;
	public Material rottenFloor;
	public Material grossFloor;
	public Material carpetedFloor;
	public Material dirtFloor;

	public Material invisibleWall;

	public Material GetInvisibleWall ()
	{
		return invisibleWall;
	}

	public Material GetMyMaterial (Themes theme)
	{
		switch (theme) {
		case Themes.Abandoned:
			return grossFloor;
			break;
		case Themes.BabyRoom:
			return woodFloor;
			break;
		case Themes.BioHazard:
			return grossFloor;
			break;
		case Themes.BodyHorror:
			return steelFloor;
			break;
		case Themes.Chemicals:
			return grossFloor;
			break;
		case Themes.ChildRoom:
			return woodFloor;
			break;
		case Themes.Crypt:
			return dirtFloor;
			break;
		case Themes.Dungeon:
			return dirtFloor;
			break;
		case Themes.ExecutionChamber:
			return steelFloor;
			break;
		case Themes.Hospital:
			return hospitalFloor;
			break;
		case Themes.Insects:
			return dirtFloor;
			break;
		case Themes.Kitchen:
			return woodFloor;
			break;
		case Themes.MedicalLab:
			return tileFloor;
			break;
		case Themes.MysticalChamber:
			return carpetedFloor;
			break;
		case Themes.PhysicalObstacles:
			return dirtFloor;
			break;
		case Themes.ScienceLaboratory:
			return grossFloor;
			break;
		case Themes.Slaughterhouse:
			return rottenFloor;
			break;
		case Themes.TortureChamber:
			return rottenFloor;
			break;
		case Themes.Victorian:
			return woodFloor;
			break;
		}
		return woodFloor;
	}
}
