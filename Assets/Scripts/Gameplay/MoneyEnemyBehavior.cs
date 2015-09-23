using UnityEngine;
using System.Collections;

public class MoneyEnemyBehavior : MonoBehaviour {

    public int myValue = 1;

	void Start () {
        if (myValue > 30)
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Diamond");
        else if (myValue > 20)
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Gold");
        else if (myValue > 10)
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Silver");
        else 
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Coins/Bronze");
		StartCoroutine(AutoDestroy());

	}
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(3f);
		this.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds(0.3f);
		this.GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds(0.5f);
		this.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds(0.2f);
		this.GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds(0.4f);
		this.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds(0.1f);
		this.GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds(0.3f);
		this.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds(0.1f);
		this.GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds(0.3f);
		this.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds(0.1f);
		this.GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds(0.3f);
		Destroy(this.gameObject);
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag.Equals("PowerUp") || col.gameObject.tag.Equals("Item"))
		{
			Physics2D.IgnoreCollision(this.gameObject.collider2D, col.gameObject.collider2D);
		}
	}
	void Update () {


		if(DirectionManager.onMousePress && collider2D.OverlapPoint(DirectionManager.worldPos))
		{
			LojaBehaviour.money += myValue;
			Destroy(this.gameObject);
		}


	}
	void OnMouseDown()
	{
        LojaBehaviour.money += myValue;
		Destroy(this.gameObject);
	}
}
