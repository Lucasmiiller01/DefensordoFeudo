using UnityEngine;
using System.Collections;

public class Fire : EnemyBehaviour {

	void Start()
	{
		this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Fire") as RuntimeAnimatorController;
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Fire/Enemy_Fire_Stop") as Sprite;
		life = 1;
		myValue = Random.Range(1, 5) * 10;
		velocity = 5;
		
	}
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.right * velocity;
    }
}
