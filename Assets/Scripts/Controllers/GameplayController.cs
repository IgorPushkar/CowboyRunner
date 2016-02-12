using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private Button restartButton;

	[SerializeField]
	private Text scoreText, pauseText;

	private int score;

	void Start(){
		scoreText.text = "" + score + "M";
		StartCoroutine (CountScore ());
	}

	IEnumerator CountScore(){
		yield return new WaitForSeconds (0.6f);
		score++;
		scoreText.text = "" + score + "M";
		StartCoroutine (CountScore ());
	}

	void OnEnable(){
		PlayerDeath.endGame += PlayerDied;
	}

	void OnDisable(){
		PlayerDeath.endGame -= PlayerDied;
	}

	void PlayerDied(){
		if(!PlayerPrefs.HasKey("Score")){
			PlayerPrefs.SetInt ("Score", 0);
		} else {
			int highscore = PlayerPrefs.GetInt ("Score");

			if(score > highscore){
				PlayerPrefs.SetInt ("Score", score);
				LeaderboardController.instance.ReportScore ();
			}
		}

		pauseText.text = "Game Over";
		pausePanel.SetActive (true);
		restartButton.onClick.RemoveAllListeners();
		restartButton.onClick.AddListener (() => RestartGame());
		Time.timeScale = 0f;
	}

	public void PauseGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartButton.onClick.RemoveAllListeners();
		restartButton.onClick.AddListener (() => ResumeGame());
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
		
	}

	public void RestartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Gameplay");
	}

	public void GoToMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
}
