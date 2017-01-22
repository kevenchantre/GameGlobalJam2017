using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wave
{
	public class PlayerControl : MonoBehaviour 
	{
		public GameObject player;
		public Animator animPlayer;
		private bool isInOcean = true;

		public AudioClip sound;

		void Start () 
		{
			animPlayer = player.GetComponentInChildren<Animator>();
			animPlayer.enabled = false;
			//player.GetComponent<Rigidbody>().velocity = Vector3.back * 20;
			player.GetComponent<Rigidbody>().AddForce(Vector3.back * 1000);
		}
		
		void Update () 
		{
			if (Input.GetKey ("up") && (!isInOcean))
			{
				animPlayer.enabled = true;
				//animPlayer.Play("Boat_Rotation");
				animPlayer.Play("Boat_Rotation", -1, 0f);
			}
			if (Input.GetKey ("down") && (!isInOcean))
			{
				animPlayer.enabled = true;
				animPlayer.Play("Boat_Rotation3");
			}
		}

		void OnCollisionEnter(Collision other)
		{
			if(other.gameObject.tag == "Ocean")
			{
				isInOcean = true;
			}
			else if(other.gameObject.tag == "Jumper")
			{
				//GetComponent<AudioSource>().PlayOneShot(sound);
				Debug.Log("Sound");
			}
		}

		void OnCollisionExit(Collision other2)
		{
			if(other2.gameObject.tag == "Ocean")
			{
				isInOcean = false;
			}
		}
	}
}
