using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainScene";


	public void Play ()
	{
		SceneManager.LoadScene(levelToLoad);
		WaveSpawner.EnemiesAlive = 0;
	}

	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

}
