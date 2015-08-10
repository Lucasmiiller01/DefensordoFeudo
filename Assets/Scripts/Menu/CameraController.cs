using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform CredtisPos;
    private Transform ConfigPos;
    public string CameraTarget;

	void Start () 
    {
        this.CredtisPos = GameObject.Find("CreditsPos").GetComponent<Transform>();
	}

    public void ChangeTarget(string target)
    {
        this.CameraTarget = target;
    }

    //mudando posição para creditos
    public void changeLocationToCredtis()
    {
        this.transform.position = Vector3.Slerp(this.transform.position, CredtisPos.position, 5 * Time.deltaTime);
    }

    //mudando posição para configurações
    public void changeLocationToConfig()
    {
        this.transform.position = Vector3.Slerp(this.transform.position, ConfigPos.position, 5 * Time.deltaTime);
    }

    //mundando posição para Menu principal
    public void changeLocationToMenu()
    {
        this.transform.position = Vector3.Slerp(this.transform.position, new Vector3(0,0,-10), 5 * Time.deltaTime);
    }

    public void ManagerOfScript()
    {
        //condições para ir ao alvo
        switch (CameraTarget)
        {
            case "Config": changeLocationToConfig();
                break;
            case "Credits": changeLocationToCredtis();
                break;
            case "Menu": changeLocationToMenu();
                break;
            
            default: ;
                break;
        }
    }

    //precisa se estar sempre atualizando se não irá acontecer bem devagar
	void FixedUpdate () 
    {
        ManagerOfScript();
	}
}
