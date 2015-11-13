using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnController : MonoBehaviour {

	private GameObject enemy;
	private GameObject spawnado;
	private string[] enemiesTypes;
	private int random_enemy;
	private Text deadEnemy;
	private float waitTime;
	private float timeSet;
	void Start () {
		deadEnemy = GameObject.Find ("NumberDead").GetComponent<Text> ();
		enemy = (GameObject)Resources.Load("Prefabs/Enemy");
		timeSet = Time.fixedTime;
		enemiesTypes = new string[]
		{
			"Commoner", 
			"Commoner", 
			"Warrior"
		
		};
	}
	void Update() {
		deadEnemy.text = Enemy.destroyerTotal.ToString();

	}
	void FixedUpdate(){
		SpawnEnemy ();
		waitTime = SetTimeSpawn(Enemy.destroyerTotal);

	}
	float SetTimeSpawn(int kills)
	{
		if (kills < 150)
			return -0.01f * kills + 2;
		else
			return 0.3f;
	}
	void SpawnEnemy(){

		if (Time.fixedTime - timeSet > waitTime)
		{
			timeSet = Time.fixedTime;
			random_enemy =  Random.Range (0, enemiesTypes.Length);
			try{
				if(this.gameObject.tag == "Spawn1")
				{
					spawnado = (GameObject) Instantiate(enemy,this.transform.position,this.transform.rotation);
					spawnado.GetComponent<EnemyBehaviour>().type = enemiesTypes[random_enemy];
				}
				if(this.gameObject.tag == "Spawn2")
				{
					spawnado = (GameObject) Instantiate(enemy,this.transform.position,this.transform.rotation);
					spawnado.GetComponent<EnemyBehaviour>().type = enemiesTypes[random_enemy];	
				}
			}
			catch{}
		}
	}

	
}
