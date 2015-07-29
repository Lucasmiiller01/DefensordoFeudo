using UnityEngine;
using System.Collections;

public class WarriorBehaviour : Enemy {

	void Start () {
		this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Warrior") as RuntimeAnimatorController;
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Guerreiro1") as Sprite;
		life = 4;
		velocity = 1;
		this.rigidbody2D.velocity = this.transform.right * velocity;
	}
}
