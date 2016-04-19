using UnityEngine;
using System.Collections;

public class DirectionManager : MonoBehaviour {

	private GameObject player;
	public static bool onMousePress = false;
	public static Vector2 worldPos;

	void Start () 
	{
		onMousePress = false;
		player = GameObject.Find("Player");
	}

	void LateUpdate () 
	{
		worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if(Input.GetButtonDown("Fire1"))
		{
			if(!CastleBehaviour.lose)
			{
				onMousePress = true;
				if(Input.mousePosition.x >  Screen.width / 2)
				{
					player.transform.eulerAngles = new Vector3(0,0,0);
				}
				else
				{
					player.transform.eulerAngles = new Vector3(0,180,0);
				}
			}
		}
		if(Input.GetButtonUp("Fire1"))
		{
			onMousePress = false;
		}
	}
}
