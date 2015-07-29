using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

	private GameObject arrow;
	private GameObject newArrow;
	private float reloadTime;
	
	void Start () 
	{
		reloadTime = 1;
		arrow = GameObject.FindGameObjectWithTag("Arrow");
		StartCoroutine(Reload());
	}



	IEnumerator Reload()
	{
		yield return new WaitForSeconds(reloadTime);
		newArrow = (GameObject) Instantiate(arrow,arrow.transform.position,arrow.transform.rotation);
		newArrow.GetComponent<SpriteRenderer>().enabled = true;
		newArrow.GetComponent<ArrowDestroyController>().enabled = true;
		newArrow.rigidbody2D.velocity = newArrow.transform.right * 5;
		StartCoroutine(Reload());
	}
}
