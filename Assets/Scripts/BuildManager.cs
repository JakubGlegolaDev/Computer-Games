using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake () {
		if (instance != null) {
			return;
		}
		instance = this;
	}
		
	public GameObject buildEffect;
	public TileUI tileUI;

	private TurretBlueprint turretToBuild;
	private Tile selectedTile;


	public void SelectTurretToBuild (TurretBlueprint turret) {
		turretToBuild = turret;
		DeselectTile ();
	}

	public void SelectTile (Tile tile) {
		if (selectedTile == tile) {
			DeselectTile ();
			return;
		}
		selectedTile = tile;
		turretToBuild = null;
		tileUI.SetTarget (tile);
	}

	public void DeselectTile () {
		selectedTile = null;
		tileUI.Hide();
	}

	public TurretBlueprint GetTurretToBuild() {
		return turretToBuild;
	}

	public bool CanBuild { get { return turretToBuild != null;} }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;} }


	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			turretToBuild = null;
		}
	}
}
