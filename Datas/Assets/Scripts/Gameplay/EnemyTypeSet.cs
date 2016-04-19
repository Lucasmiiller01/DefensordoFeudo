using UnityEngine;
using System.Collections;

public class EnemyTypeSet : EnemyBehaviour {

	public string type;
	public static GameObject money;

	void Start () 
	{
		money = (GameObject)Resources.Load("Prefabs/Money");
		switch (type)
		{
			case "Fire":
				this.gameObject.AddComponent<Fire>();
				break;
			case "Water":
				this.gameObject.AddComponent<Water>();
				break;
			case "Air":
				this.gameObject.AddComponent<Air>();
				break;
			case "Stone":
				this.gameObject.AddComponent<Stone>();
				break;
			default:
				this.gameObject.AddComponent<Default>();
				break;

		}
	}
}
public class EnemyBehaviour : MonoBehaviour
{
	protected float velocity = 1;
	protected float life = 1;
    protected int damaged = 1;
    protected int myValue = 1;
	public static int destroyer = 0;
	public static int destroyerTotal = 0;
	public static bool dead = false;
	bool item = false;


	void Start () 
	{
		item = false;
		destroyer = 0;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("Arrow") && this.transform.position.x > -27f && this.transform.position.x < 27f)
		{
			Destroy(col.gameObject);
			if(this.gameObject.GetComponent<EnemyTypeSet>().type.Equals(col.name))
				life -= LojaBehaviour.damage;
		}
		if(col.gameObject.tag.Equals("Castle"))
		{
			this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Animator>().SetBool("inCastle", true);
            StartCoroutine(Damage(col.gameObject)); 
		}
	}
    IEnumerator Damage(GameObject Castle)
    {
        Castle.GetComponent<CastleBehaviour>().DamageMe(damaged);
        yield return new WaitForSeconds(1);
        StartCoroutine(Damage(Castle));
    }
	

	void Update()
	{

		if(life <= 0){
			if (!item)
			{
				GameObject drop = (GameObject) Instantiate(EnemyTypeSet.money, this.transform.position, this.transform.rotation);
				drop.GetComponent<MoneyEnemyBehavior>().myValue = myValue;
			}
			item = true;
			destroyer += 1;
			destroyerTotal += 1;
			Destroy(this.gameObject);
		}
		
	}
}
