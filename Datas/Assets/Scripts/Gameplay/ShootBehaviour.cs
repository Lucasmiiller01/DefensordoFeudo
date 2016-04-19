using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

	private GameObject arrow;
	private GameObject newArrow;

	
	void Start () 
	{
		arrow = GameObject.FindGameObjectWithTag("Arrow");
	}
	public void Shoot (string name)
    {
        newArrow = (GameObject)Instantiate(arrow, arrow.transform.position, arrow.transform.rotation);
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
        newArrow.GetComponent<ArrowDestroyController>().enabled = true;
		newArrow.name = name;
        newArrow.GetComponent<Rigidbody2D>().velocity = newArrow.transform.right * 5 * 10;
	}
}
