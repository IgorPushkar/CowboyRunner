using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using System.Collections;

public class LeaderboardController : MonoBehaviour {

	public static LeaderboardController instance;

	private const string ID = "CgkIupXUwfIYEAIQBw";

	private Button leaderboardButton;

	void Awake(){
		MakeSingleton ();
	}

	void Start(){
		PlayGamesPlatform.Activate ();
	}

	void OnLevelWasLoaded(){
		if(SceneManager.GetActiveScene().name == "MainMenu"){
			GetButton ();
			ReportScore ();
		}
	}

	void GetButton(){
		leaderboardButton = GameObject.Find ("Leaderboard Button").GetComponent<Button> ();
		leaderboardButton.onClick.RemoveAllListeners ();
		leaderboardButton.onClick.AddListener (() => OpenLeaderboardsScore ());
	}

	void MakeSingleton(){
		if(instance != null){
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void OpenLeaderboardsScore(){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (ID);
		} else {
			Social.localUser.Authenticate ((bool success) => {});
		}
	}

	public void ReportScore(){
		if (Social.localUser.authenticated) {
			Social.ReportScore (PlayerPrefs.GetInt("Score"), ID, (bool success) => {});
		}
	}
}
