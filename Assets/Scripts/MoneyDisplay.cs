using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

	void Update () {
		GetComponent<Text>().text = "$" + GameMaster.instance.money.ToString("0.00");
	}
}
