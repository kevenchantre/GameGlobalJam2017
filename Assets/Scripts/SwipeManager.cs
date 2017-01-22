using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour 
{
	public List<Vector3> playerPosition = new List<Vector3>();

	private Vector2 fp;  // a posicao do inicio do toque
	private Vector2 lp;  // a posicao do final do toque
	int actualPosition = 0;

	public float speed = 5;

	bool move = false;
	public int swipeSpeed = 0;
	public float turnSpeed = 10.0f;
	float stepParc = 10.0f;

	public Transform turnCenter;
	public Transform turnLeft;
	public Transform turnRight;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(move)
		{
			Turn();
		}
		NoTouch();
	}

	void Swipe()
	{
	foreach (Touch touch in Input.touches)
	{
          if (touch.phase == TouchPhase.Began)
          {
               fp = touch.position;
               lp = touch.position;
          }
          if (touch.phase == TouchPhase.Moved )
          {
                lp = touch.position;
          }
          if(touch.phase == TouchPhase.Ended)
          { 
         	 if((fp.x - lp.x) > swipeSpeed) // left swipe
         	{
                actualPosition = actualPosition - 1;
                if(actualPosition < -1)
                {
                	actualPosition = -1;
                }
                ChangeLine();
          	}
          	else if((fp.x - lp.x) < -swipeSpeed) // right swipe
          	{
                actualPosition = actualPosition + 1;
                 if(actualPosition > 1)
                {
                	actualPosition = 1;
                }
                ChangeLine();
          	}
          	else if((fp.y - lp.y) < -swipeSpeed ) // up swipe
          	{
                
          	}
          	else if((fp.y - lp.y) > -swipeSpeed ) // Down swipe
          	{
               
          	}
     	}
 	}
}

void ChangeLine()
{	
	move = true;
}

void NoTouch()
{
	if ((Input.GetKeyDown ("left")) || (Input.GetKeyDown ("a")))
	{
		 actualPosition = actualPosition - 1;
         if(actualPosition < -1)
          {
                actualPosition = -1;
          }
          ChangeLine();
	}
	else if ((Input.GetKeyDown ("right")) || (Input.GetKeyDown ("d")))
	{
		actualPosition = actualPosition + 1;
        if(actualPosition > 1)
        {
            actualPosition = 1;
        }
        ChangeLine();
	}
}

void Turn()
{
	Vector3 direction;
	Quaternion newLookRotation;
	float step = stepParc * Time.deltaTime;
	
	 if(actualPosition == 0)
	{
		transform.position = Vector3.MoveTowards(transform.position, turnCenter.position, step);
		direction = (transform.position - turnCenter.position);
	}
	else  if(actualPosition < 0)
	{
		transform.position = Vector3.MoveTowards(transform.position, turnLeft.position, step);
		direction = (transform.position - turnLeft.position);
	}
	else  if(actualPosition > 0)
	{
		transform.position = Vector3.MoveTowards(transform.position, turnRight.position, step);
		direction = (transform.position - turnRight.position);
	}
	else
	{
		direction = (transform.position - turnRight.position);
	}
	//newLookRotation = Quaternion.LookRotation(direction);
	//transform.rotation = Quaternion.Slerp(transform.rotation, newLookRotation, turnSpeed * Time.deltaTime);
}

}
