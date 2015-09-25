using UnityEngine;
using System.Collections;

public class LoginGUI : MonoBehaviour {

	public DatabaseConnection _mysqlHolder;

	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 300, 30), "MySql Connection State: " + _mysqlHolder.GetConnectionState ());
	}

}
