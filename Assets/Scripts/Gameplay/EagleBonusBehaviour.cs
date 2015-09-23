using UnityEngine;
using System.Collections;

public class EagleBonusBehaviour : MonoBehaviour {

    void Start()
    {
        if (this.transform.position.x > 0)
            this.transform.Rotate(0, 180, 0);
        this.rigidbody2D.velocity = this.transform.right * -3 * 10;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
