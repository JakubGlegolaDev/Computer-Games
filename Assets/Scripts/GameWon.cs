using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour {

	public Text roundText;
	public string menuSceneName = "MainMenu";

	void OnEnable () {
		roundText.text = PlayerStats.Rounds.ToString();
	}

	public void Replay () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		WaveSpawner.EnemiesAlive = 0;
	}

	public void Menu () {
		SceneManager.LoadScene(menuSceneName);
	}
}
