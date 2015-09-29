using UnityEngine;
using System.Collections;

public class FadeDestroy : MonoBehaviour {

	void Start ()
    {
		StartCoroutine(AutoDestroy());
	}
	
    public IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
	
}
