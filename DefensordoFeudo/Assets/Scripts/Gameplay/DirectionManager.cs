using UnityEngine;
using System.Collections;

public class DirectionManager : MonoBehaviour {

	private GameObject player;

	void Start () 
	{
		player = GameObject.Find("Player");
	}

	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(Input.mousePosition.x >  Screen.width / 2)
				player.transform.eulerAngles = new Vector3(0,0,0);
			else
				player.transform.eulerAngles = new Vector3(0,180,0);
		}
	}
}
