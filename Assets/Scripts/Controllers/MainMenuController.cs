using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene ("Gameplay");
	}

	public void Quit(){
		Application.Quit ();
	}
}
