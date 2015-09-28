using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnController : MonoBehaviour {

	private GameObject enemy;
	private GameObject spawnado;
	public static int spawnadoo; 
	private string[] enemiesTypes;
	private int random;
	private int random_enemy;
	public static int stage;
	private Text t_Stage;
	private Text deadEnemy;
	private int TotalDead;
	void Start () {

		stage = 1;
		spawnadoo = 0;
		t_Stage = GameObject.Find ("Stage").GetComponent<Text> ();
		deadEnemy = GameObject.Find ("deadEnemy").GetComponent<Text> ();
		enemy = (GameObject)Resources.Load("Prefabs/Enemy");
		enemiesTypes = new string[]
		{
			"Commoner", 
			"Commoner", 
			"Warrior"
		
		};
		StartCoroutine(Spawn(10));
	}
	void Update() {
		deadEnemy.text = Enemy.destroyerTotal.ToString();
		t_Stage.text = "Stage:  " + stage.ToString();
		if(Enemy.destroyer >= 10){
			stage += 1;
			Enemy.destroyer = 0;
			spawnadoo = 0;
		}

	}

	
	IEnumerator Spawn(int number)
	{
		random = Random.Range (0,10);
		random_enemy =  Random.Range (0, enemiesTypes.Length);
		yield return new WaitForSeconds(Random.Range(0.1f,Mathf.Pow(0.93f,(stage - 25))));
		try{
	
			if(this.gameObject.tag == "Spawn1" && random >= 0 &&  random <= 5 && spawnadoo < number){
					spawnado = (GameObject) Instantiate(enemy,this.transform.position,this.transform.rotation);
				spawnado.GetComponent<EnemyBehaviour>().type = enemiesTypes[random_enemy];
					spawnadoo += 1;
				}
			if(this.gameObject.tag == "Spawn2" && random > 5 && spawnadoo < number){
					spawnado = (GameObject) Instantiate(enemy,this.transform.position,this.transform.rotation);
				spawnado.GetComponent<EnemyBehaviour>().type = enemiesTypes[random_enemy];
					spawnadoo += 1;
				}
		}
		catch{
		}

		if(Enemy.destroyer < number)StartCoroutine(Spawn(int.Parse(Mathf.Floor(number + (number/100) * 20).ToString())));
	}
	
}
