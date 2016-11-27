using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LojaBehaviour : MonoBehaviour {

    public float money;
    public static float damage;

	public Text moneyState;
    public Image[] scene;
    public SpriteRenderer myPerson;
	public GameObject Arm;
    public Sprite[] person;
	public Sprite[] tiro;
    public Sprite[] basic;
	public Sprite[] hell;
    public Text[] texts;
    public GameObject menu;
    public GameObject insertNewName;
    public GameObject insertName;
    private int valueNewNome;
    private string myUpgrades;
    private string activedperso;
    private string activedS;
    public Sprite[] spites = new Sprite[2];
    private float value;
    private string upgrade;
    int textsSkin;

    void Awake()
	{

        if (ZPlayerPrefs.HasKey("ws_name"))
        {
            GameObject.Find("NameInsert").SetActive(false);
            menu.SetActive(true);
        }

    }

	void Start()
    {

        if (ZPlayerPrefs.HasKey("ws_myUpgrades"))
            myUpgrades = ZPlayerPrefs.GetString("ws_myUpgrades");

        if (ZPlayerPrefs.HasKey("ws_money"))
            money = ZPlayerPrefs.GetInt("ws_money");

        string[] acquiredUp;
        acquiredUp = ZPlayerPrefs.GetString("ws_myUpgrades").Split('|');
        foreach (string verify in acquiredUp)
        {
            if (verify.Equals("Hell"))
            {
                if (ZPlayerPrefs.GetString("ws_activedS") == verify)
                {
                    for (int i = 0; i < scene.Length; i++)
                    {
                        scene[i].sprite = hell[i];
                    }
                    texts[4].text = verify + " Ative";
                }
                else texts[4].text = verify + " Acquired";
            }
            else if (verify.Equals("Hunter"))
            {
               
                if (ZPlayerPrefs.GetString("ws_activedperso") == verify)
                {
                     myPerson.sprite = person[1];
                    texts[0].text = verify + " Ative";
                }
                else texts[0].text = verify + " Acquired";
            }
            else  if (verify.Equals("Hippie"))
            {
               

                if (ZPlayerPrefs.GetString("ws_activedperso") == verify)
                {
                    myPerson.sprite = person[3];
                    texts[1].text = verify + " Ative";
                }
                else texts[1].text = verify + " Acquired";

            }
        }

       
       
        EnemyBehaviour.destroyerTotal = 0;
        damage = 1f;
		moneyState.text = money.ToString ();

	}
	public void SetName (GameObject texto) {
		if(texto.GetComponent<Text>().text != "" && texto.GetComponent<Text>().text != null)
		{
			insertName.SetActive(false);
			ZPlayerPrefs.SetString("ws_name", texto.GetComponent<Text>().text);
		}
		else 
		{
			menu.SetActive(false);
			insertName.SetActive(true);
		}
	}
    public void SetNewName(GameObject texto)
    {
        if (texto.GetComponent<Text>().text != "" && texto.GetComponent<Text>().text != null)
        {
            insertNewName.SetActive(false);
            ZPlayerPrefs.SetString("ws_name", texto.GetComponent<Text>().text);
            money -= valueNewNome;
            ZPlayerPrefs.SetInt("ws_money", int.Parse(money.ToString()));
            moneyState.text = money.ToString();
        }
        else 
        {
            insertNewName.SetActive(true);
        }

    }
    public void DecreaseCoin(int value1)
    {
        if(money > value1)
        {
            insertNewName.SetActive(true);
            valueNewNome = value1;
        }

    }
    public void Scene (string scene) {
        SceneManager.LoadScene(scene);
	}


    public void SumCoin(int value)
	{
		money += value;
        if (money > 1000000)
            moneyState.text = ((Mathf.Floor(money / 100000)) / 10).ToString() + "M";
        else if (money > 10000)
            moneyState.text = ((Mathf.Floor(money / 100)) / 10).ToString() + "K";
        else
            moneyState.text = money.ToString();
        ZPlayerPrefs.SetInt("ws_money", int.Parse(money.ToString()));
	}
  
    public void SetValue(float values)
    {
        value = values;
    }
    public void SetUpgrade(string upgrades)
    {
        upgrade = upgrades;
    }
	public void BuyAndSelect(GameObject texts)
    {
        Text text = texts.GetComponent<Text>();
		bool iHave = false;
        if (myUpgrades != null && myUpgrades != "")
        {
            string[] acquiredUp;
            acquiredUp = myUpgrades.Split('|');
            foreach (string verify in acquiredUp)
            {
                if (verify.Equals(upgrade))
                {
                    iHave = true;
                }
            }
        }
        if (iHave)
        {
            if (text.text.Equals(upgrade + " Ative") && upgrade != "Hell")
            {
                text.text = upgrade + " Acquired";
                DesactivePerson();
                ZPlayerPrefs.SetString("ws_activedperso", "");
            }
            else if(text.text.Equals(upgrade + " Ative") && upgrade == "Hell")
            {
                DesactiveScene();
                text.text = upgrade + " Acquired";
                ZPlayerPrefs.SetString("ws_activedS", "");
            }
            else
            {
                ActiveUpgrade(text);
            }
        }
        else if (money >= value)
        {
           
                myUpgrades +=  "|" + upgrade;   
                ActiveUpgrade(text);
                SumCoin(int.Parse((value * -1).ToString()));
                ZPlayerPrefs.SetString("ws_myUpgrades", myUpgrades);
        }
	}
    void Update()
    {

        if (activedperso != null && activedperso.Equals("Hunter") && textsSkin != 0) textsSkin = 0;
        else if (activedperso != null && activedperso.Equals("Hippie") && textsSkin != 1) textsSkin = 1;


    }

    void ActiveUpgrade(Text text)
    {
        if (activedperso != upgrade) texts[textsSkin].text = activedperso + " Acquired";
        text.text = upgrade + " Ative";
        if(upgrade.Equals("Hell"))
        {
            for (int i = 0; i < scene.Length; i++)
            {
                scene[i].sprite = hell[i];
                activedS = upgrade;
                ZPlayerPrefs.SetString("ws_activedS", activedS);
            }
          
        }
        if (upgrade.Equals("Hunter"))
        {
            myPerson.sprite = person[1];
            activedperso = upgrade;
            ZPlayerPrefs.SetString("ws_activedperso", activedperso);

        }
        if (upgrade.Equals("Mage"))
        {
            myPerson.sprite = person[2];
            activedperso = upgrade;
            ZPlayerPrefs.SetString("ws_activedperso", activedperso);
        }
        if (upgrade.Equals("Hippie"))
        {
            activedperso = upgrade;
            myPerson.sprite = person[3];
            ZPlayerPrefs.SetString("ws_activedperso", activedperso);

        }
    }
    void DesactivePerson()
    {
        myPerson.sprite = person[0];
    }
    void DesactiveScene()
    {
        for (int i = 0; i < scene.Length; i++)
        {
            scene[i].sprite = basic[i];
        }
    }
}