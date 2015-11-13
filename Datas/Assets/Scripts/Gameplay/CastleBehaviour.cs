using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleBehaviour : MonoBehaviour {

	public static bool lose;
	public GameObject gameOver;
    static float life;
	private float atualnumber;
	public Text score_t;
	public Text record_t;
	private float opa ;
	private float record;
	public GameObject newrecord;


	void Start () {
		atualnumber = 0;
		lose = false;
	}
	void FixedUpdate () 
	{
		if (lose) {
			SumToScore (Enemy.destroyerTotal);
			record = PlayerPrefs.GetFloat("Record");
		}
	}
	void SumToScore(float myScore)
	{
		if (atualnumber < myScore && 0.2f <= Time.fixedTime - opa)
		{
			opa = Time.fixedTime;
			atualnumber ++;
		}
		score_t.text = "Your Score:\n" + atualnumber.ToString ();
		record_t.text = "Your Best:\n" + record.ToString();
	}
    public void DamageMe(float damaged)
	{
		GameObject canvas = GameObject.Find("Canvas");
		canvas.GetComponent<Canvas>().sortingOrder = 5;
		gameOver.SetActive(true);
		lose = true;
		opa = Time.fixedTime;
		GetComponent<ScoreManaher> ().enabled = true;
		if (PlayerPrefs.HasKey ("Record") && Enemy.destroyerTotal > PlayerPrefs.GetFloat ("Record") || !PlayerPrefs.HasKey("Record")) 
		{
			PlayerPrefs.SetFloat("Record", Enemy.destroyerTotal);
			newrecord.SetActive(true);

		}


    }
}
