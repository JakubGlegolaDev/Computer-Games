using UnityEngine;
using UnityEngine.UI;
//using System.Runtime.CompilerServices;
//using System.Threading;

public class Enemy : MonoBehaviour {

	public float initSpeed = 10f;
	[HideInInspector]
	public float speed;

	public float initHealth = 100;
	private float health;

	public int value = 10;
	public GameObject destroyEffect;
	private bool isDead = false;

	[Header("Unity Stuff")]
	public Image lifeBar;

	void Start() {
		speed = initSpeed; 
		health = initHealth;
	}
		
	public void TakeDamage (float amount) {
		health -= amount;

		float perc = health / initHealth;
		lifeBar.fillAmount = perc;

		if (perc < 0.2) {
			lifeBar.color = Color.red;
		} else if (perc < 0.5) {
			lifeBar.color = Color.yellow;
		}

		if (health <= 0 && !isDead) {
			Die ();
		}
	}

	public void Slow (float amount) {
		speed = initSpeed * (1f - amount); 
	}


	void Die () {
		isDead = true;
		PlayerStats.Money += value;
		GameObject effect = (GameObject)Instantiate (destroyEffect, transform.position, Quaternion.identity);
		Destroy (effect, 2f);
		WaveSpawner.EnemiesAlive--;
		Destroy (gameObject);
	}

}
