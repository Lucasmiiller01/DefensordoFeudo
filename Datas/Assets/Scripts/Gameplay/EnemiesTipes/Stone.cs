using UnityEngine;
using System.Collections;

public class Stone : EnemyBehaviour {
	
	void Start () 
	{
		this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Enemies/Stone") as RuntimeAnimatorController;
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/Enemies/Stone/Enemy_Stone_Stop") as Sprite;
        this.GetComponent<SpriteRenderer>().color = new Color(0.96f, 0.96f, 0.86f);
        life = 1;
        myValue = Random.Range(1, 5) * 10;
        velocity = 5;
	}
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.right * velocity;
    }
}
