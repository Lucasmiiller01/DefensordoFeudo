using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    private GameObject player;
	void Start () {
        player = GameObject.Find("Player");
        StartCoroutine(LeaveMe());
    }
	void Update()
	{
		if(DirectionManager.onMousePress && GetComponent<Collider2D>().OverlapPoint(DirectionManager.worldPos))
		{
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag.Equals("PowerUp") || col.gameObject.tag.Equals("Item"))
		{
			Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
		}
	}
    void RandomBonus()
    {
        int randomize = Random.Range(0, 0);
        if (randomize.Equals(0))
        {
        }
    }
    IEnumerator LeaveMe()
    {
        yield return new WaitForSeconds(Random.Range(0,1.8f));
		this.gameObject.GetComponent<DistanceJoint2D>().enabled = false;
		transform.parent = null;
		StartCoroutine(AutoDestroy());
    }

	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(4f);
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
    void OnMouseDown()
    {
        RandomBonus();
        Destroy(this.gameObject);
    }
}
