using UnityEngine;
using System.Collections;

public class WarriorBehaviour : Enemy {

	void Start () {
		this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Warrior") as RuntimeAnimatorController;
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Guerreiro1") as Sprite;
		life = 1;
		velocity = 1;
        myValue = Random.Range(1, 5) * 10;
		this.rigidbody2D.velocity = this.transform.right * velocity * 10;
	}
}
