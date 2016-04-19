using UnityEngine;
using System.Collections;

public class Fire : EnemyBehaviour {

	void Start()
	{
		this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Warrior") as RuntimeAnimatorController;
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Guerreiro1") as Sprite;
		this.GetComponent<SpriteRenderer> ().color = Color.red;
		life = 1;
		myValue = Random.Range(1, 5) * 10;
		velocity = 5;
		
	}
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.right * velocity;
    }
}
