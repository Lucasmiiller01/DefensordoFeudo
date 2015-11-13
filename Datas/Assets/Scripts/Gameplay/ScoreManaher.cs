using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManaher : MonoBehaviour {
	private string url;
	public GameObject loja;
	


	void Start () {
		url = "http://supermanfans.16mb.com/Conecta.php";
		SetScoreToData();
	}
	


	void SetScoreToData()
	{
		WWWForm rada = new WWWForm();
		rada.AddField("score", Enemy.destroyerTotal);

		rada.AddField("nome", PlayerPrefs.GetString("name"));

		WWW www = new WWW(url,rada);

	}
}
