using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour 
{
	public GameObject[] RoadPieces = new GameObject[2];
	const float RoadLength = 550f; //length of roads

	const float RoadSpeed = 200f; //speed to scroll roads at

	public Vector3 newRoadPos;
	void Update ()
	{
		foreach (GameObject road in RoadPieces)
		{
			newRoadPos = road.transform.position;
			newRoadPos.z = newRoadPos.z - RoadSpeed * Time.deltaTime;
			if (newRoadPos.z < -RoadLength / 2)
			{
				newRoadPos.z += RoadLength;
			}
			road.transform.position = newRoadPos;
		}
	}
}
