using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Wave
{
	public class ScoreManager : MonoBehaviour 
	{
		public Text txtScore;
		public int score;
		private int scoreToAdd;
		public AudioClip sound;
		void Start () 
		{
			
		}

		public void addScore()
		{
			score = score + scoreToAdd;
			txtScore.text = score.ToString();
		}

		void OnTriggerEnter(Collider trigger) 
		{
			if(trigger.tag == "Coin")
			{
				Destroy(trigger.gameObject);
				GetComponent<AudioSource>().PlayOneShot(sound);
				scoreToAdd = 1;
				addScore();
			}
			else if(trigger.tag == "Speeder")
			{
				GetComponent<Rigidbody>().AddForce(Vector3.back * 150);
				scoreToAdd = 3;
				addScore();
			}
			else if(trigger.tag == "Victory")
			{
				SceneManager.LoadScene("Victory");
			}
		}

		void OnCollisionEnter(Collision collision)
		{
			if(collision.gameObject.tag == "Enemy")
			{
				SceneManager.LoadScene("MainMenu");
			}
		}
	}	
}
