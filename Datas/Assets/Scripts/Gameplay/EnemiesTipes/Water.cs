using UnityEngine;
using System.Collections;

public class Ice : EnemyBehaviour {
	
	void Start ()
    {
        this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Ice") as RuntimeAnimatorController;
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Stone/Enemy_Ice_Stop") as Sprite;
		life = 1;
        myValue = Random.Range(1, 5) * 10;
        velocity = 5;
		this.GetComponent<Rigidbody2D>().velocity = this.transform.right * velocity;
	}
}
