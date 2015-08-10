using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleBehaviour : MonoBehaviour {

	public Text V_Castle;
	public static int life = 100;
	void Start () {
		V_Castle = GameObject.Find ("V_Castle").GetComponent<Text> ();
	}
	
	void Update () {
		V_Castle.text = "Vida Castle : " + life.ToString ();
	}
}
