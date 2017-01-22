using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBalance : MonoBehaviour 
{
	static bool wayPoint = true;
	public float speed = 1.0f;
	private Vector3 pointA;
	public Transform pointB;


	void Start () 
	{
		if(wayPoint)
		{
			pointA = transform.position;
			while(true)
			{
				float i = Mathf.PingPong(Time.time * speed, 1);
				transform.position = Vector3.Lerp(pointA, pointB.position, i);
				//transform.localPosition.z = Mathf.Lerp(pointA.y, transform.localPosition.z, Time.deltaTime * 1);
				//return yield;
			}
		}
	}
	
}
