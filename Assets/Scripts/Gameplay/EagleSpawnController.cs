using UnityEngine;
using System.Collections;

public class EagleSpawnController : MonoBehaviour {

    private GameObject PowerUp;
    void Start()
    {
        PowerUp = (GameObject)Resources.Load("Prefabs/Eagle");
        StartCoroutine(Instantiate());
	}
    IEnumerator Instantiate()
    {
        int side = Random.Range(0, 2);
        Vector2 spawn;
        if (side.Equals(0)) spawn = new Vector2(3.6f, Random.Range(0,1.7f));
        else spawn = new Vector2(-3.6f, Random.Range(0,1.7f));
        yield return new WaitForSeconds(Random.Range(7,20));
        Instantiate(PowerUp, spawn, this.transform.rotation);
        StartCoroutine(Instantiate());
    }
    
}
