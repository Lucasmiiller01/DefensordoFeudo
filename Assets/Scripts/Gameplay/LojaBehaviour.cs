using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LojaBehaviour : MonoBehaviour {

	public class upgrade
	{
		public int level;
		public int ratio;
		public int price;
		
		public void levelUp(int effect)
        {
            level += 1;
            money -= price;
			price = level * ratio;
            if (effect.Equals(0))
                damage += price / 200;
			if (effect.Equals (1))
				CastleBehaviour.life += price / 25;
            if (effect.Equals(2))
                farm += level * level;
		}
	}

	public static int money;
    public static int farm;
    public static float damage;
	public Text moneyState;
	public GameObject[] itens;
	public GameObject[] off;
	public Text[] itens_t;
    public GameObject hud;
	public GameObject castle;
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
		bonus[0].ratio = 100;
		bonus[1].price = 200;
		bonus[1].ratio = 200;
        bonus[2].price = 50;
        bonus[2].ratio = bonus[2].price;
		bonus[3].price = 70;
		bonus[3].ratio = 70;
		money = 0;
		StartCoroutine(Money());
	}

	public void item(int number)
	{
        if (money > bonus[number].price)
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
                if (i < off.Length)
                {
                    off[i].SetActive(false);
                }
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
			itens_t [i].text = "Money " + bonus [i].price + "  Lvl  " + bonus [i].level;
		}

		moneyState.text = "Gold : " +  money.ToString();
        if (money > 10000)
            moneyState.text = "Gold : " + ((Mathf.Floor(money / 100)) / 10).ToString() + "K";
        if (money > 1000000)
            moneyState.text = "Gold : " + ((Mathf.Floor(money / 100000)) / 10).ToString() + "M";

	}
}