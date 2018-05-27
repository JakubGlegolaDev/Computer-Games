using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject gameOverUI;
	public GameObject levelCompleteUI;
	public GameObject gameWonUI;



	public static bool GameIsOver;
	public static bool LevelIsChecked = false;

	void Start () {
		GameIsOver = false;
	}

	void Update () {
		if (GameIsOver) {
			return;
		}

		if (Input.GetKeyDown ("e")) {
			EndGame ();
		}

		if (PlayerStats.Lives <= 0) {
			EndGame ();
		}
		if (!LevelIsChecked && PlayerStats.Rounds % WaveSpawner.WavesPerLevel == 0 && PlayerStats.Rounds != 0 && WaveSpawner.EnemiesAlive == 0){
			
			LevelComplete ();
		}
		if (PlayerStats.Rounds % WaveSpawner.WavesPerLevel != 0)
			LevelIsChecked = false;

	}

	void EndGame () {
		GameIsOver = true;
		gameOverUI.SetActive (true);
		StartCoroutine (Pause());


	}
	void LevelComplete () {
		
		levelCompleteUI.SetActive (true);
	}

	public void WinGame () {
		GameIsOver = true;
		gameWonUI.SetActive (true);
	}

	IEnumerator Pause() {
		yield return new WaitForSeconds (1);
		Time.timeScale = 0f;
	}
}
