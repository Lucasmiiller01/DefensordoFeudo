using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LojaBehaviour : MonoBehaviour {

    public static float money;
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
    public GameObject insertName;

    private string myUpgrades;
    private string activedperso;
    private string activedS;
    public Sprite[] spites = new Sprite[2];
    private float value;
    private string upgrade;


    void Awake()
	{

        if (PlayerPrefs.HasKey("name"))
        {
            GameObject.Find("NameInsert").SetActive(false);
            menu.SetActive(true);
        }

    }

	void Start()
    {
        if (PlayerPrefs.HasKey("myUpgrades"))
            myUpgrades = PlayerPrefs.GetString("myUpgrades");

        string[] acquiredUp;
        acquiredUp = PlayerPrefs.GetString("myUpgrades").Split('|');
        foreach (string verify in acquiredUp)
        {
            if (verify.Equals("Hell"))
            {
                if (PlayerPrefs.GetString("activedS") == verify)
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
               
                if (PlayerPrefs.GetString("activedperso") == verify)
                {
                     myPerson.sprite = person[1];
                    texts[0].text = verify + " Ative";
                }
                else texts[0].text = verify + " Acquired";
            }
            else  if (verify.Equals("Hippie"))
            {
               

                if (PlayerPrefs.GetString("activedperso") == verify)
                {
                    myPerson.sprite = person[3];
                    texts[1].text = verify + " Ative";
                }
                else texts[1].text = verify + " Acquired";

            }
        }

        if (PlayerPrefs.HasKey("money"))
           money = PlayerPrefs.GetFloat("money");
        EnemyBehaviour.destroyerTotal = 0;
        damage = 1f;
		moneyState.text = money.ToString ();

	}
	public void SetName (GameObject texto) {
		if(texto.GetComponent<Text>().text != "" && texto.GetComponent<Text>().text != null)
		{
			insertName.SetActive(false);
			PlayerPrefs.SetString("name", texto.GetComponent<Text>().text);
		}
		else 
		{
			menu.SetActive(false);
			insertName.SetActive(true);
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
        PlayerPrefs.SetFloat("money", money);
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
                PlayerPrefs.SetString("activedperso", "");
            }
            else if(text.text.Equals(upgrade + " Ative") && upgrade == "Hell")
            {
                DesactiveScene();
                text.text = upgrade + " Acquired";
                PlayerPrefs.SetString("activedS", "");
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
            SumCoin(int.Parse((value *-1).ToString()));
            PlayerPrefs.SetString("myUpgrades", myUpgrades);
        }
	}
    void ActiveUpgrade(Text text)
    {
        text.text = upgrade + " Ative";
        if(upgrade.Equals("Hell"))
        {
            for (int i = 0; i < scene.Length; i++)
            {
                scene[i].sprite = hell[i];
                activedS = upgrade;
                PlayerPrefs.SetString("activedS", activedS);
            }
          
        }
        if (upgrade.Equals("Hunter"))
        {
            myPerson.sprite = person[1];
            activedperso = upgrade;
            PlayerPrefs.SetString("activedperso", activedperso);

        }
        if (upgrade.Equals("Mage"))
        {
            myPerson.sprite = person[2];
            activedperso = upgrade;
            PlayerPrefs.SetString("activedperso", activedperso);
        }
        if (upgrade.Equals("Hippie"))
        {
            activedperso = upgrade;
            myPerson.sprite = person[3];
            PlayerPrefs.SetString("activedperso", activedperso);

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