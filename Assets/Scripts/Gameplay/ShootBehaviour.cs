using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

	private GameObject arrow;
	private GameObject newArrow;
	private float reloadTime;
	private bool onReloading;
	
	void Start () 
	{
		reloadTime = 1;
		arrow = GameObject.FindGameObjectWithTag("Arrow");
		StartCoroutine(Reload());
	}
    public IEnumerator Bonus()
    {
        reloadTime = 0.2f;
        yield return new WaitForSeconds(4);
        reloadTime = 1;
    }
	public void Shoot ()
	{
		if(!onReloading)
		{
			newArrow = (GameObject) Instantiate(arrow,arrow.transform.position,arrow.transform.rotation);
			newArrow.GetComponent<SpriteRenderer>().enabled = true;
			newArrow.GetComponent<ArrowDestroyController>().enabled = true;
			newArrow.rigidbody2D.velocity = newArrow.transform.right * 5;
			//StartCoroutine(Reload());
		}
	}

	IEnumerator Reload()
	{
		onReloading = true;
		yield return new WaitForSeconds(reloadTime);
		onReloading = false;

	}
}
