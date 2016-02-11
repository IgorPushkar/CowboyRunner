using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private AudioClip jumpClip;

	private float jumpForce = 12f, forwardForce = 0f;

	private Rigidbody2D myBody;

	private Animator anim;

	private bool canJump;

	private bool isCollided;

	private Button jumpButton;

	void Awake (){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		jumpButton = GameObject.Find ("Jump Button").GetComponent<Button> ();
		jumpButton.onClick.AddListener (() => Jump ());
	}

	void Update () {
		if(Mathf.Abs(myBody.velocity.y) == 0){
			canJump = true;
			if(isCollided){
				anim.Play ("Idle");
			} else {
				anim.Play ("Run");
			}

		}
	}

	public void Jump(){
		if(canJump){
			canJump = false;

//			AudioSource.PlayClipAtPoint (jumpClip, transform.position);

			anim.Play ("Jump");

			if(transform.position.x < 0){
				forwardForce = 1f;
			} else {
				forwardForce = 0f;
			}

			myBody.velocity = new Vector2 (forwardForce, jumpForce);

		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Obstacle"){
			anim.Play ("Idle");
			isCollided = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision){
		if(collision.gameObject.tag == "Obstacle"){
			anim.Play ("Jump");
			isCollided = false;
		}
	}
}
