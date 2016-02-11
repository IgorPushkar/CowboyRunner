using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	public delegate void EndGame();
	public static event EndGame endGame;

	void PlayerDied(){
		if(endGame != null){
			endGame ();
		}

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Collector"){
			PlayerDied ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Zombie"){
			PlayerDied ();
		}
	}
}
