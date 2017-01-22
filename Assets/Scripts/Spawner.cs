using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public List<GameObject> objectsCollection = new List<GameObject>();
	public List<GameObject> objectsCreated = new List<GameObject>();
	public List<Vector3> positionList = new List<Vector3>();
	GameObject object_;
	void Start () 
	{
		InstanciateObjects();
		InvokeRepeating("BuildObject", 0, Random.Range(1,2));
	}

    void InstanciateObjects()
    {	
        for (int count = 0; count < objectsCollection.Count; count++)
        {
            object_ = objectsCollection[count];
            object_.SetActive(false);
            object_ = Instantiate(object_);
            objectsCreated.Add(object_);
        }
    }

    void BuildObject()
    {
        object_ = objectsCreated[Random.Range(0, objectsCreated.Count)];
        if (!object_.activeInHierarchy)
        {
            ObjectPosition();
            object_.SetActive(true);
        }
        else
        {
            object_ = Instantiate(object_);
            ObjectPosition();
            object_.SetActive(true);
        }
    }

    void ObjectPosition()
    {
        Vector3 posObject = positionList[Random.Range(0, positionList.Count)];
        object_.transform.position = posObject;
    }
}
