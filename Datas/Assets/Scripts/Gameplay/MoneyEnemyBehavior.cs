using UnityEngine;
using System.Collections;

public class MoneyEnemyBehavior : MonoBehaviour {

	private Transform finalPosition;
	public int myValue = 1;
	private GameObject loja;

	void Start () {
		loja = GameObject.FindGameObjectWithTag("Loja");

		finalPosition = GameObject.Find ("PosToGo").transform;
        if (myValue > 30)
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Diamond");
        else if (myValue > 20)
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Gold");
        else if (myValue > 10)
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Silver");
        else 
			this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Bronze");

	}
	void Update () {

		this.transform.position = Vector3.Lerp (this.transform.position, finalPosition.position,0.05f);
		if(Mathf.Round(this.transform.position.y).Equals(Mathf.Round(finalPosition.position.y)))
		{
			loja.GetComponent<LojaBehaviour>().SumCoin(myValue);
			Destroy(this.gameObject);
		}
	}
}
