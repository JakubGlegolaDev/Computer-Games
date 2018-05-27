using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTarget : MonoBehaviour {

	[Header("General")]
	public float range = 20f;

	[Header("Use Bullets (default)")]
	public GameObject bulletPrefab;
	public float fireRate = 1f;
	private float fireCooldown = 0f;

	[Header("Use Laser")]
	public bool useLaser = false;
	public int damageOverTime = 30;
	public float slowAmount = .5f;
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;


	[Header("System Setup")]
	public Transform partToRotate;
	public bool fullRotation = true;
	public float rotationSpeed = 200f;
	public string enemytag = "Enemy";
	private Transform target;
	private Enemy targetScript;


	public GameObject firePoint;

	// Use this for initialization
	void Start() {

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget() {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemytag);
		float shortestDist = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) {
			float dist = Vector3.Distance (transform.position, enemy.transform.position);
			if (dist < shortestDist) {
				shortestDist = dist;
				nearestEnemy = enemy;
			}

		}

		if (nearestEnemy != null && shortestDist <= range) {
			target = nearestEnemy.transform;
			targetScript = nearestEnemy.GetComponent<Enemy>();
		}
		else
			target = null;
	}

	void Update () {
		if (target == null) {
			if (useLaser) {
				if (lineRenderer.enabled) {
					impactEffect.Stop ();
					lineRenderer.enabled = false;
					impactLight.enabled = false;

				}
			}
			return;
		}
		LockOnTarget ();

		if (useLaser) {
			Laser ();
		} else {
			if (fireCooldown <= 0f) {
				Shoot ();
				fireCooldown = 1f / fireRate;
			}

			fireCooldown -= Time.deltaTime;
		}
	}

	void LockOnTarget () {
		Vector3 direction = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		if (fullRotation)
			partToRotate.rotation = Quaternion.RotateTowards (partToRotate.rotation, lookRotation, rotationSpeed * Time.deltaTime);
		else {
			Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
			partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
		}
	}

	void Laser () {
		targetScript.TakeDamage (damageOverTime * Time.deltaTime);
		targetScript.Slow (slowAmount);

		if (!lineRenderer.enabled) {
			lineRenderer.enabled = true;
			impactEffect.Play ();
			impactLight.enabled = true;
		}

		lineRenderer.SetPosition (0, firePoint.transform.position);
		lineRenderer.SetPosition (1, target.position);
		Vector3 dir = firePoint.transform.position - target.position;
		impactEffect.transform.rotation = Quaternion.LookRotation (dir);

		impactEffect.transform.position = target.position + dir.normalized * .5f;;
	}


	void Shoot() {

		GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null) {
			bullet.Aim (target);
		
		}
	}
}
