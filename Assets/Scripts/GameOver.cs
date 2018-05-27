using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Text roundText;
	public string menuSceneName = "MainMenu";

	void OnEnable () {
		roundText.text = PlayerStats.Rounds.ToString();
	}

	public void Retry () {
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		WaveSpawner.EnemiesAlive = 0;
	}

	public void Menu () {
		Time.timeScale = 1f;
		SceneManager.LoadScene(menuSceneName);
	}
}
