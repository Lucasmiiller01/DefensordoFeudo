﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManaher : MonoBehaviour {
	private string link;



    void Start () {
        link = "http://supermanfans.16mb.com/index.php";
        SetScoreToData();
	}
	


	void SetScoreToData()
	{
        StartCoroutine(SetScore(EnemyBehaviour.destroyerTotal, PlayerPrefs.GetString("name"), link));
    
    }

    IEnumerator SetScore(int score, string name, string url)
    {
        WWW w = new WWW(link + "?service=set&score=" + score + "&nome=" + name);
        yield return new WaitForSeconds(.5f);
        yield return w;

        if (!string.IsNullOrEmpty(w.error))
        {
            print(w.error);
        }
        else {
            switch (w.text)
            {
                case "1":
                    print("Sucesso");
                    break;
                case "-1":

                    print( "Erro ao cadastrar.");
    
                    break;

                default:
                    print(w.text);
                    break;
            }
        }

    }


}
