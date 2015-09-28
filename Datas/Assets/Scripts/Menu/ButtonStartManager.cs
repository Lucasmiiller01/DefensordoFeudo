using UnityEngine;
using System.Collections;

public class ButtonStartManager : MonoBehaviour {

    public GameObject canvas;

    IEnumerator AutoDestroction()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }

    void OnMouseDown()
    {
        this.gameObject.GetComponent<Animator>().SetInteger("AnimationState", 1);
        StartCoroutine(AutoDestroction());
    }
	
}
