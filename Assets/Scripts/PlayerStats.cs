using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public static int Lives;

	public int startMoney = 400;
	public int startLives = 20;
	public static int Rounds;

	public void Start () {
		Money = startMoney;
		Lives = startLives;
		Rounds = 0;
	}

}
