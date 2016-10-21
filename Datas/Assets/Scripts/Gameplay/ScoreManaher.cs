using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManaher : MonoBehaviour {
	private string link;



    void Start () {
        link = "http://defensor.16mb.com/set.php";
        if (ZPlayerPrefs.GetInt("ws_record") > 0) SetScoreToData();
	}
	


	void SetScoreToData()
	{
        StartCoroutine(SetScore(ZPlayerPrefs.GetInt("ws_record"), ZPlayerPrefs.GetString("ws_name") != null && ZPlayerPrefs.GetString("ws_name") != "" ? ZPlayerPrefs.GetString("ws_name") : "Defalt Player", link));
    }

    IEnumerator SetScore(int score, string name, string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", name);
        form.AddField("Record", score);
        WWW w = new WWW(url, form);
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
