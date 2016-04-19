using UnityEngine;
using System.Collections;

public class Water : EnemyBehaviour {
	
	void Start () 
	{
		this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Warrior") as RuntimeAnimatorController;
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Guerreiro1") as Sprite;
		this.GetComponent<SpriteRenderer> ().color = Color.blue;
		life = 1;
        myValue = Random.Range(1, 5) * 10;
        velocity = 5;
		this.GetComponent<Rigidbody2D>().velocity = this.transform.right * velocity;
	}
}
