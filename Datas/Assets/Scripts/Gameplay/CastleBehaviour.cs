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
	public int record;
    private bool mandou;
    public GameObject newrecord;
    private bool isEncriptionInitialized;

    void Awake()
    {
        InicializeEncryotion();

    }
    void Start () {
		atualnumber = 0;
		lose = false;
        mandou = false;

    }
	void Update () 
	{
		if (lose) {
			SumToScore (EnemyBehaviour.destroyerTotal);
			if(!mandou) record = ZPlayerPrefs.GetInt("ws_record");
            mandou = true;
		}
	}
    void InicializeEncryotion()
    {
        if (!!isEncriptionInitialized)
        {
            if(!PlayerPrefs.HasKey("ws_id"))
            {
                PlayerPrefs.SetString("ws_id", Random.Range(1000000,999999).ToString());
                ZPlayerPrefs.Initialize("CHAVE_DE_ENCRIPTACAO", "Sd" + PlayerPrefs.GetString("ws_id") + "ds");
            }
        }
    }
    void SumToScore(float myScore)
	{

        if (atualnumber < myScore && atualnumber / (myScore * (myScore + 1 - atualnumber) - atualnumber) <= Time.fixedTime - opa)
        {
           
            opa = Time.fixedTime;
			atualnumber ++;
		}
		score_t.text = "Your Score:" + atualnumber.ToString();
        record_t.text = "Your Best:" + record.ToString();
	}
   
	public void DamageMe(float damaged)
	{
        GameObject canvas = GameObject.Find("Canvas BG");
		canvas.GetComponent<Canvas>().sortingOrder = 5;
		gameOver.SetActive(true);
		lose = true;
      
		GetComponent<ScoreManaher> ().enabled = true;
		if (ZPlayerPrefs.HasKey ("ws_record") && EnemyBehaviour.destroyerTotal > ZPlayerPrefs.GetInt ("ws_record") || !ZPlayerPrefs.HasKey ("ws_record")) {
            ZPlayerPrefs.SetInt ("ws_record", EnemyBehaviour.destroyerTotal);
			newrecord.SetActive (true);

		}
    }
}
