using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayfabLogin : MonoBehaviour
{
    public Mutiphoton mu;

    public GameObject logOrSignPanel;
    public GameObject loginPanel;
    public InputField user;
    public InputField pass;
    public InputField email;
    public Text message;
    public bool IsAuthenticated = false;

    public GameObject submit;
    public GameObject loginBut;
    public GameObject LoginCanvas;
    public GameObject CreateOrJoinCanvas;
    //public GameObject alpaca;
    //public GameObject farmer;

    //button
    /*public Button alpaca1;
    public Button alpaca2;
    public Button alpaca3;
    public Button hunter1;
    public Button hunter2;
    public Button hunter3;*/



    string status = "";

    LoginWithPlayFabRequest loginRequest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotoRegis()
    {
        logOrSignPanel.SetActive(false);
        loginPanel.SetActive(true);
        status = "regis";
    }

    public void gotoLogin()
    {
        logOrSignPanel.SetActive(false);
        loginPanel.SetActive(true);
        email.gameObject.SetActive(false);
        user.text = "";
        pass.text = "";
        status = "login";
        submit.SetActive(true);
        loginBut.SetActive(false);
    }

    public void backToButton()
    {
        logOrSignPanel.SetActive(true);
        loginPanel.SetActive(false);
        email.gameObject.SetActive(true);
        status = "";
        user.text = "";
        pass.text = "";
        email.text = "";
        submit.SetActive(true);
        loginBut.SetActive(false);
    }
    public void Hide()
    {
        LoginCanvas.SetActive(false);
    }

    public void select()
    {
        if(status == "regis")
        {
            Register();
        }
        else if(status == "login")
        {
            login();
        }
    }

    public void login()
    {
        print("login!!");
        loginRequest = new LoginWithPlayFabRequest();
        loginRequest.Username = user.text;
        loginRequest.Password = pass.text;
        PlayFabClientAPI.LoginWithPlayFab(loginRequest, result => {
            //if account is found.
            mu.ConnectToMaster();
            message.text = "Welcome " + user.text + ", Connecting";
            IsAuthenticated = true;
            LoginCanvas.SetActive(false);
            CreateOrJoinCanvas.SetActive(true);
         

            Debug.Log("You Are Now Log in!!");
        }, error => {
            //if acoount is not found.
            message.text = "failed login " + error.ErrorMessage + " " + user.text + " " + pass.text;
            IsAuthenticated = false;
            //email.gameObject.SetActive(true);
            Debug.Log(error.ErrorMessage);
        }, null);
    }

    public void Register()
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
        request.Email = email.text;
        request.Username = user.text;
        request.Password = pass.text;
        PlayFabClientAPI.RegisterPlayFabUser(request, result =>
        {
            message.text = "Your account has been created";
            submit.SetActive(false);
            loginBut.SetActive(true);

        }, error =>
        {
            message.text = "failed create " + error.ErrorMessage;
        });
    }

   
}
