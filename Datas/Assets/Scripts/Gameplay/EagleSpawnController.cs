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
        int side = Random.Range(0, 30);
        Vector2 spawn;
        if (side.Equals(0)) spawn = new Vector2(31, Random.Range(0,11));
		else spawn = new Vector2(-31, Random.Range(0,11));
        yield return new WaitForSeconds(Random.Range(7,20));
        Instantiate(PowerUp, spawn, this.transform.rotation);
        StartCoroutine(Instantiate());
    }
    
}
