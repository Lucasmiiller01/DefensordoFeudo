using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public string type;
	void Start () 
	{
		switch (type)
		{
			case "Commoner":
			case "Plebeu":
				this.gameObject.AddComponent<CommonerBehaviour>();
				break;
			case "Warrior":
			case "Guerreiro":
				this.gameObject.AddComponent<WarriorBehaviour>();
				break;
			default:
				this.gameObject.AddComponent<CommonerBehaviour>();
				break;

		}
	}

}



public class Enemy : MonoBehaviour
{
	protected float velocity = 1;
	protected int life = 1;
	

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("Arrow"))
		{
			Destroy(col.gameObject);
			life -= 1;
		}
		if(col.gameObject.tag.Equals("Castle"))
		{
			this.rigidbody2D.velocity = Vector2.zero;
			this.GetComponent<Animator>().SetBool("inCastle",true);
		}
	}
	void Update()
	{
		if(life.Equals(0))
			Destroy(this.gameObject);
	}

}
