using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System.Collections.Generic;

public class FacebookManager : MonoBehaviour
{

    private static FacebookManager _instance;
    public CastleBehaviour castleBehaviour;
    public static FacebookManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject fbm = new GameObject("FBManager");
                fbm.AddComponent<FacebookManager>();
            }
            return _instance;
        }
    }

    public bool isLoggedIn { get; set; }
    public string profileName { get; set; }
    public Sprite profilePic { get; set; }
    public string appLinkURL { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
        isLoggedIn = true;
    }
    public void InitFB()
    {
        if (!FB.IsInitialized)
        {
            enabled = false;
            FB.Init(SetInit, OnHideUnity);
        }
        else isLoggedIn = FB.IsLoggedIn;

    }
    private void SetInit()
    {
        enabled = true;
        if (FB.IsLoggedIn)
        {
            Debug.Log("FB logged in");
            GetProfile();

        }
        else {
            Debug.Log("FB is not logged in");
        }
        isLoggedIn = FB.IsLoggedIn;
    }

    private void OnHideUnity(bool isGameShown)
    {
        Debug.Log("OnHideUnity");
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void GetProfile()
    {
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
        FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);

    }
    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            profileName = "" + result.ResultDictionary["first_name"];
        }
        else {
            Debug.Log(result.Error);
        }
    }
    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            profilePic = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }

    }

    public void Share()
    {
        FB.FeedShare(
             string.Empty, new System.Uri("https://www.youtube.com/watch?v=hSTivVclQQ0"), "Defensor Do Feudo ", "Melhor jogo ", "Meu recorde no Defensor foi" + "  " + castleBehaviour.record.ToString(), new System.Uri("https://www.google.com.br/search?q=Venha+jogar&espv=2&source=lnms&tbm=isch&sa=X&ved=0ahUKEwjkvcqr34TOAhVnJMAKHRBZCgQQ_AUICCgB&biw=1920&bih=955#imgrc=l3L_n2rjBSIGLM%3A"), string.Empty, ShareCallback
         );
    }
    void ShareCallback(IResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Share Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error)) Debug.Log("Error on Shared!");
        else if (string.IsNullOrEmpty(result.RawResult)) Debug.Log("Sucess on SHared");
    }
    public void Invite()
    {
        FB.Mobile.AppInvite(
             new System.Uri("https://www.youtube.com/watch?v=hSTivVclQQ0"), new System.Uri("http://forcaeinteligencia.com/wp-content/uploads/2013/09/batata-ou-batata-doce.png"), InviteCallBack
         );
    }
    void InviteCallBack(IResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Invite Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error)) Debug.Log("Invite on Shared!");
        else if (string.IsNullOrEmpty(result.RawResult)) Debug.Log("Invite on SHared");
    }
    public void ShareWithUsers()
    {
       // FB.AppRequest("Opa", null, new List<object>() { "app_users" }, null, null, null, null, ShareWithUsersCallBack);

    }
    void ShareWithUsersCallBack(IAppRequestResult result)
    {
        Debug.Log(result.RawResult);
        if (result.Cancelled)
        {
            Debug.Log("Challange Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error)) Debug.Log("Challange on Shared!");
        else if (string.IsNullOrEmpty(result.RawResult)) Debug.Log("Challange on SHared");
    }
}