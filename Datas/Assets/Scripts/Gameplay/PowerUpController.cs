using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    private GameObject player;
    private GameObject[]  images;

    void Start () {
        player = GameObject.Find("Player");
        images = GameObject.FindGameObjectsWithTag("botoes");

    }
	void Update()
	{
		if(DirectionManager.onMousePress && GetComponent<Collider2D>().OverlapPoint(DirectionManager.worldPos))
		{
			Destroy(this.gameObject);
            player.GetComponent<ShootBehaviour>().arrowSpecial = true;
            for (int i = 0; i < images.Length; i++)
            {
                images[i].GetComponent<Image>().color = Color.black;
            }
        }
	}
 
 
    void OnMouseDown()
    {
        Destroy(this.gameObject);
        player.GetComponent<ShootBehaviour>().arrowSpecial = true;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].GetComponent<Image>().color = Color.black;
        }
    }
}
