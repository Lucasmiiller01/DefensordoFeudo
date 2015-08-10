using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnController : MonoBehaviour {

	private GameObject enemy;
	private GameObject spawnado;
	public static int spawnadoo; 
	private string[] enemiesTypes;
	private int random;
	public static int stage;
	private Text t_Stage;
	private Text deadEnemy;
	void Start () {
		stage = 1;
		spawnadoo = 0;
		t_Stage = GameObject.Find ("Stage").GetComponent<Text> ();
		deadEnemy = GameObject.Find ("deadEnemy").GetComponent<Text> ();
		enemy = (GameObject)Resources.Load("Prefabs/Enemy");
		StartCoroutine(Destroy());
		enemiesTypes = new string[]
		{
			"Commoner", 
			"Commoner",
			"Warrior",
			"Warrior",
			"Warrior",
			"Warrior"
		};
	}
	void Update() {
		deadEnemy.text = "DeadEnemy" +  Enemy.destroyer.ToString()  +   "/"  +   "10";
		t_Stage.text = "Stage :  " + stage.ToString();
		if(Enemy.destroyer == 10){
			stage += 1;
			Enemy.destroyer = 0;
			spawnadoo = 0;
		}

	}

	
	IEnumerator Destroy()
	{
		random = Random.Range (0,14);
		yield return new WaitForSeconds(Random.Range(1,4));
		try{
	
			if(this.gameObject.tag == "Spawn1" && random >= 0 &&  random <= 5 && spawnadoo <= 9){
					spawnado = (GameObject) Instantiate(enemy,this.transform.position,this.transform.rotation);
					spawnado.GetComponent<EnemyBehaviour>().type = enemiesTypes[stage];
					spawnadoo += 1;
				}
			if(this.gameObject.tag == "Spawn2" && random > 5 && spawnadoo <= 9){
					spawnado = (GameObject) Instantiate(enemy,this.transform.position,this.transform.rotation);
					spawnado.GetComponent<EnemyBehaviour>().type = enemiesTypes[stage];
					spawnadoo += 1;
				}
		}
		catch{
		}

		if(Enemy.destroyer < 10)StartCoroutine(Destroy());
	}
	
}
