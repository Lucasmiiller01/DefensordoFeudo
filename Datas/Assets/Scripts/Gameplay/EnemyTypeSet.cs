using UnityEngine;
using System.Collections;

public class EnemyTypeSet : EnemyBehaviour {

	private string type;
	private GameObject money;

	void Start () 
	{
		money = (GameObject)Resources.Load("Prefabs/Money");
		
	}
    public void SetMyType(string myType)
    {
        if(myType.Equals("Fire") || myType.Equals("Ice") || myType.Equals("Stone"))
        {
            type = myType;
            switch (type)
            {
                case "Fire":
                    this.gameObject.AddComponent<Fire>();
                    break;
                case "Ice":
                    this.gameObject.AddComponent<Ice>();
                    break;
                case "Stone":
                    this.gameObject.AddComponent<Stone>();
                    break;

            }
        }
    }
    public string GetMyType()
    {
        return type;
    }
    public GameObject GetMyValue()
    {
        return money;
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
			if(this.gameObject.GetComponent<EnemyTypeSet>().GetMyType().Equals(col.name))
				life -= LojaBehaviour.damage;
            else if(col.name.Equals("all")) life -= LojaBehaviour.damage;
        }
		if(col.gameObject.tag.Equals("Castle"))
		{
			this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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

		if(life <= 0 && !CastleBehaviour.lose){
			if (!item)
			{
				GameObject drop = (GameObject) Instantiate(this.gameObject.GetComponent<EnemyTypeSet>().GetMyValue(), this.transform.position, this.transform.rotation);
				drop.GetComponent<MoneyEnemyBehavior>().myValue = myValue;
			}
			item = true;
			destroyer += 1;
			destroyerTotal += 1;
			Destroy(this.gameObject);
		}
        if (CastleBehaviour.lose) Destroy(this.gameObject);
		
	}
}
