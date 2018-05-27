using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int waypointIndex = 0;
	private Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
		target = Waypoints.points [0];
	}

	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		//Enemy.SetDestination (MoveTarget.position);
		if (Vector3.Distance (transform.position, target.position) <= 0.2f) {
			GetNextWaypoint ();
		}

		enemy.speed = enemy.initSpeed;
	}

	void GetNextWaypoint () {
		if (waypointIndex >= Waypoints.points.Length - 1) {
			EndPath ();
			return;
		}
		waypointIndex++;
		target = Waypoints.points[waypointIndex];
	}

	void EndPath () {
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy (gameObject);
	}
}
