static var Waypoint : boolean = true;
private var pointA : Vector3;
var pointB : Transform;
var speed = 1.0;
 
function Start () 
{
    if(Waypoint == true) 
    {
    	pointA = transform.position;
        while (true) 
        {
        	var i = Mathf.PingPong(Time.time * speed, 1);
            transform.position = Vector3.Lerp(pointA, pointB.position, i);
            yield;
        }
    }   
}