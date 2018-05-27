using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

	public Text levelText;
	public GameObject ui;
	private int level = 0;

	void OnEnable () {
		level = Mathf.FloorToInt (PlayerStats.Rounds / WaveSpawner.WavesPerLevel);
		levelText.text = "LEVEL " + level + " COMPLETE";
		Time.timeScale = 0f;
	}

	void Continue ()
	{
		GameManager.LevelIsChecked = true;
		ui.SetActive(!ui.activeSelf);
		Time.timeScale = 1f;
	}
}

