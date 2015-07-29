using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	private GameObject enemy;
	private GameObject spawnado;  
	private string[] enemiesTypes;
	void Start () {
		enemy = (GameObject)Resources.Load("Prefabs/Enemy");
		StartCoroutine(Destroy());
		enemiesTypes = new string[]
		{
			"Commoner", 
			"Commoner",
			"Commoner",
			"Warrior",
			"Warrior"
		};
	}
	
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(Random.Range(1,4));
		spawnado = (GameObject) Instantiate(enemy,this.transform.position,this.transform.rotation);
		spawnado.GetComponent<EnemyBehaviour>().type = enemiesTypes[Random.Range(0, enemiesTypes.Length - 1)];
		StartCoroutine(Destroy());
	}
}
