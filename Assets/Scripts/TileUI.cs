using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour {
	
	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;

	public Text sellAmount;

	private Tile target;

	public void SetTarget (Tile _target) {
		target = _target;

		transform.position = target.GetBuildPosition();

		if (!target.isUpgraded) {
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		} else {
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

		ui.SetActive (true);
	}

	public void Hide () {
		ui.SetActive (false);
	}

	public void Upgrade () {
		target.UpgradeTurret ();
		BuildManager.instance.DeselectTile ();
	}

	public void Sell() {
		target.SellTurret ();
		BuildManager.instance.DeselectTile ();
	}
}
