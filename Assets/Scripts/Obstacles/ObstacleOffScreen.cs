using UnityEngine;
using System.Collections;

public class ObstacleOffScreen : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Collector"){
			gameObject.SetActive (false);
		}
	}
}
