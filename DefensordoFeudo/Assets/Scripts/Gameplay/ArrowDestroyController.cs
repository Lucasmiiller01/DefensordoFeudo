using UnityEngine;
using System.Collections;

public class ArrowDestroyController : MonoBehaviour {

	void Start () {
		
		StartCoroutine(Destroy());
	}
	
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
}
