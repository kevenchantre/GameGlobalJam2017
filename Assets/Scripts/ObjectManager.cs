using UnityEngine;

public class ObjectManager : MonoBehaviour 
{
	public bool isRotating = false;
	public int speed = 0;

	void FixedUpdate () 
	{
		Rotating();
	}

	public void Rotating()
	{
		if(isRotating)
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * speed);
		}
	}
}
