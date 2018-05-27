using UnityEngine;

public class Shop : MonoBehaviour {
	public TurretBlueprint standardTurret;
	public TurretBlueprint crystalTurret;
	public TurretBlueprint deathStar;

	BuildManager buildManager;

	public void SelectStandardTurret(){
		buildManager.SelectTurretToBuild (standardTurret);
	}

	public void SelectCrystalTurret(){
		buildManager.SelectTurretToBuild (crystalTurret);
	}

	public void SelectDeathStar(){
		buildManager.SelectTurretToBuild (deathStar);
	}

	// Use this for initialization
	void Start () {
		buildManager = BuildManager.instance;
	}
}
