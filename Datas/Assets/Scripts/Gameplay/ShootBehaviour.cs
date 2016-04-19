using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

	private GameObject arrow;
	private GameObject newArrow;
    public GameObject[] images;
    public bool arrowSpecial;



    void Start () 
	{
		arrow = GameObject.FindGameObjectWithTag("Arrow");
	}
	public void Shoot (string name)
    {
        newArrow = (GameObject)Instantiate(arrow, arrow.transform.position, arrow.transform.rotation);
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
        newArrow.GetComponent<ArrowDestroyController>().enabled = true;
		
        if (arrowSpecial)
        {
            newArrow.name = "all";
            for (int i = 0; i < images.Length; i++)
            {
                images[i].GetComponent<Image>().color = Color.white;
            }
            arrowSpecial = false;
        }
        else newArrow.name = name;
        newArrow.GetComponent<Rigidbody2D>().velocity = newArrow.transform.right * 5 * 10;
	}
}
