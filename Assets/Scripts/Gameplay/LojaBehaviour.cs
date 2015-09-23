using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LojaBehaviour : MonoBehaviour {

	public class upgrade
	{
		public float level;
        public float ratio;
        public float price;
		
		public void levelUp(int effect)
        {
            level += 1;
            money -= price;
			price =  Mathf.Pow(level ,ratio) + price;
            if (effect.Equals(0))
                damage += price / 200;
            else if (effect.Equals(1))
			{
                CastleBehaviour.maxLife += level * 10 * (CastleBehaviour.maxLife / 100);
			}
            else if (effect.Equals(2))
                farm += level * level;
		}
	}

    public static float money;
    public static float farm;
    public static float damage;
	public Text moneyState;
	public GameObject[] itens;
	public GameObject[] off;
	public Text[] itens_t;
    public GameObject hud;
    public upgrade[] bonus = new upgrade[4];

	void Start()
	{
        farm = 0;
        damage = 0.3f;
		for (int i = 0; i < bonus.Length; i++)
		{
			bonus[i] = new upgrade();
			bonus[i].level = 1;
		}
		bonus[0].price = 100;
		bonus[0].ratio = 7;
		bonus[1].price = 50;
		bonus[1].ratio = 6;
        bonus[2].price = 50;
        bonus[2].ratio = 5;
		bonus[3].price = 70;
		bonus[3].ratio = 3;
		money = 0;
		StartCoroutine(Money());
	}

	public void item(int number)
	{
        if (money >= bonus[number].price)
        {
            bonus[number].levelUp(number);
        }
	}
	public void Loja()
	{
		if(itens[1].activeSelf == false){
            hud.SetActive(true);
            for (int i = 0; i < itens.Length; i++)
            {
                itens[i].SetActive(true);
            }
		}
        else
        {
            hud.SetActive(false);
            for (int i = 0; i < itens.Length; i++)
            {
                itens[i].SetActive(false);
                if (i < off.Length)
                {
                    off[i].SetActive(true);
                }
            }
				
		}
	}

	IEnumerator Money()
	{
		yield return new WaitForSeconds(2);
		money += farm;
		StartCoroutine(Money());
	}

	void Update () {

		for (int i = 0; i < bonus.Length; i++) 
		{
            if (bonus[i].price > 1000000)
                itens_t[i].text = "Money " + ((Mathf.Floor(bonus[i].price / 100000)) / 10).ToString() + "M"  + "  Lvl  " + bonus[i].level;
            else if (bonus[i].price > 1000)
                itens_t[i].text = "Money " + ((Mathf.Floor(bonus[i].price / 100)) / 10).ToString() + "K" + "  Lvl  " + bonus[i].level;
            else
                itens_t[i].text = "Money " + bonus[i].price + "  Lvl  " + bonus[i].level;
		}
        if (money > 1000000)
            moneyState.text = ((Mathf.Floor(money / 100000)) / 10).ToString() + "M"; 
        else if (money > 10000)
            moneyState.text = ((Mathf.Floor(money / 100)) / 10).ToString() + "K";
        else
		    moneyState.text = money.ToString();
	}
}