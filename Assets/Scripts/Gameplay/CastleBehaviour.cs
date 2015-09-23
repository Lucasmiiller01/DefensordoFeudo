using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleBehaviour : MonoBehaviour {

	public Text V_Castle;
	public static float maxLife;
	public static bool lose;
	public Image[] bars;
	public Image gameOver;
    static float life;
	void Start () {
		lose = false;
        maxLife = 100;
        life = maxLife;
		V_Castle = GameObject.Find ("V_Castle").GetComponent<Text> ();
	}
	void VerifyBarLife()
	{
		int myValue = 0;
		maxLife = Mathf.Floor(maxLife);
		for (int i = 0; i < bars.Length; i++)
		{
			bars [i].enabled = true;
		}
		if(life <= 0)
		{
			myValue = -1;
			GameObject canvas = GameObject.Find("Canvas");
			canvas.GetComponent<Canvas>().sortingOrder = 5;
			gameOver.enabled = true;
			lose = true;
		}
		else if(life <= (maxLife / 100) * 16)
			myValue = 0;
		else if(life <= (maxLife / 100) * 32)
			myValue = 1;
		else if(life <= (maxLife / 100) * 48)
			myValue = 2;
		else if(life <= (maxLife / 100) * 64)
			myValue = 3;
		else if(life <= (maxLife / 100) * 80)
			myValue = 4;
		else if(life <= (maxLife / 100) * 100)
			myValue = 6;
		
		for (int i = 5; i > myValue; i--)
		{
			bars [i].enabled = false;
		}

	}
	void FixedUpdate () {
		VerifyBarLife ();
		V_Castle.text = life.ToString () + " / " + maxLife;


	}
    public static void HealMe()
    {
        float heal = Random.Range(5, 40);
        life += Mathf.Floor( heal * (maxLife/100));
        if (life > maxLife) life = maxLife;
    }
    public void DamageMe(float damaged)
    {
        life -= damaged;
    }
}
