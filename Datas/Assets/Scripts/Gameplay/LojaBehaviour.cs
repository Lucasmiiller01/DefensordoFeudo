using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    public GameObject menu;
    public GameObject insertName;

    private string myUpgrades;
    private string skin_backgound;
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
            myUpgrades = PlayerPrefs.GetString("myUpgrade");
        if (PlayerPrefs.HasKey("money"))
            money = PlayerPrefs.GetFloat("money");
        Enemy.destroyerTotal = 0;
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
		Application.LoadLevel (scene);
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
        if (myUpgrades != null & myUpgrades != "")
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
            if (text.text.Equals(upgrade + " Ative"))
            {
                text.text = upgrade + " Acquired";
                DesactiveScene();
            }
            else
            {
                ActiveUpgrade(text);
            }
        }
        else if (money >= value)
        {
          
            myUpgrades += "|" + upgrade;
            print(myUpgrades);
            PlayerPrefs.SetString("myUpgrades", myUpgrades);
            print(PlayerPrefs.GetString("myUpgrades"));
            ActiveUpgrade(text);
            SumCoin(int.Parse((value *-1).ToString()));
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
            }
        }
        else if (upgrade.Equals("Hunter"))
        {
            myPerson.sprite = person[1];

        }
        else if (upgrade.Equals("Mage"))
        {
            myPerson.sprite = person[2];
        }
        else if (upgrade.Equals("Hippie"))
        {
            myPerson.sprite = person[3];
			Arm.GetComponent<SpriteRenderer>().sprite = tiro[1];

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