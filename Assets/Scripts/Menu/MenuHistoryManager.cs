using UnityEngine;
using System.Collections;

public class MenuHistoryManager : MonoBehaviour {

    public float speed;

	void Start ()
    {
        if (this.tag.Equals("Amy"))
        {
            this.speed = 2.5f * Time.deltaTime;
        }

        if (this.name.Equals("Plebeu"))
        {
            this.speed = 2.5f * Time.deltaTime;
        }
	}

    IEnumerator StartBeseker()
    {
        yield return new WaitForSeconds(13);

        if (this.name.Equals("Ogro"))
        {
            this.transform.Translate(-1.5f * Time.deltaTime,0,0);
        }
    }

    void Move()
    {
        if (!this.name.Equals("AllFundo"))
        {
            this.transform.Translate(this.speed, 0, 0);

            if (this.transform.position.x < -16.11f && this.tag.Equals("Amy"))
            { this.transform.rotation = new Quaternion(0, 0, 0, 0); }

            if (this.transform.position.x < -16.11f && this.name.Equals("Plebeu"))
            { this.transform.rotation = new Quaternion(0, 0, 0, 0); }

            if (this.transform.position.x > 12.45f && this.name.Equals("Plebeu"))
            { this.transform.rotation = new Quaternion(0, 180, 0, 0); }

            if (this.transform.position.x > 12.45f && this.tag.Equals("Amy"))
            { this.transform.rotation = new Quaternion(0, 180, 0, 0); }
        }
        else if (!Camera.main.GetComponent<CameraController>().CameraTarget.Equals("Credits") && this.name.Equals("AllFundo"))
        { 
            this.transform.Translate(1 * Time.deltaTime, 0, 0);
            if (this.transform.position.x > -8.4f)
            { this.transform.position = new Vector2(-135.3985f, this.transform.position.y); }
        }
        else if (Camera.main.GetComponent<CameraController>().CameraTarget.Equals("Credits") && this.name.Equals("AllFundo"))
        {
            this.transform.position = new Vector2(-135.3985f, this.transform.position.y);
        }

    }
	
	void FixedUpdate () 
    {
        Move();
        StartCoroutine(StartBeseker());
	}
}
