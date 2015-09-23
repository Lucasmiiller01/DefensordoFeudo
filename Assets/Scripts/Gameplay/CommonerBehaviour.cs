using UnityEngine;
using System.Collections;

public class CommonerBehaviour : Enemy {

	void Start () {
		this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Commoner") as RuntimeAnimatorController;
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Plebeu1") as Sprite;
		life = 1;
        myValue = Random.Range(1,3) * 10;
		velocity = 2;
		this.rigidbody2D.velocity = this.transform.right * velocity * 10;
	}
}
