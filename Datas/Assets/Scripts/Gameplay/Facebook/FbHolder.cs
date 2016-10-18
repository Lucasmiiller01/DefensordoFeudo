using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System.Collections.Generic;
using System.Collections;


public class FbHolder : MonoBehaviour {

    public GameObject dialogLoggenIn;
    public GameObject dialogLoggenOut;
    public GameObject dialogUserName;
    public GameObject dialogProfilePic;

    void Awake()
    {
        DealWithFBMenu(FB.IsLoggedIn);
        FacebookManager.Instance.InitFB();

    }


    public void FBLogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        FB.LogInWithReadPermissions(permissions, AuthCallback);
    }
 

    private void AuthCallback(IResult result)
    {
        if(result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                FacebookManager.Instance.isLoggedIn = true;
                FacebookManager.Instance.GetProfile();
            }
            else {
              
            }
            DealWithFBMenu(FB.IsLoggedIn);
        }
    }
    void DealWithFBMenu(bool isLoggedIn)
    {
        if(isLoggedIn)
        {
            dialogLoggenIn.SetActive(true);
            dialogLoggenOut.SetActive(false);
            if(FacebookManager.Instance.profileName != null)
            {
                Text textName = dialogUserName.GetComponent<Text>();
                textName.text = "Hi, " + FacebookManager.Instance.profileName;

            }
            else
            {
                StartCoroutine("WaitForProfileName");
            }
            if (FacebookManager.Instance.profilePic != null)
            {
                Image profilePic = dialogProfilePic.GetComponent<Image>();
                profilePic.sprite = FacebookManager.Instance.profilePic;

            }
            else
            {
                StartCoroutine("WaitForProfilePic");
            }
        }
        else
        {
            dialogLoggenIn.SetActive(false);
            dialogLoggenOut.SetActive(true);
        }
    }
    IEnumerator WaitForProfileName()
    {

        while (FacebookManager.Instance.profileName == null)
        {
            yield return null;
        }
        DealWithFBMenu(FB.IsLoggedIn);
    }
    IEnumerator WaitForProfilePic()
    {

        while (FacebookManager.Instance.profilePic == null)
        {
            yield return null;
        }
        DealWithFBMenu(FB.IsLoggedIn);
    }

    public void Share()
    {
        FacebookManager.Instance.Share();
    }
    public void Invite()
    {
        FacebookManager.Instance.Invite();
    }
    public void ShareWithUser()
    {
        FacebookManager.Instance.ShareWithUsers();
    }
}



