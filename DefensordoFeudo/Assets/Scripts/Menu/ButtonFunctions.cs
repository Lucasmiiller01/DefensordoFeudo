using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        Application.LoadLevel(scene);
    }

    public void DesableObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void EnableObject(GameObject obj)
    {
        obj.SetActive(true);
    }
}