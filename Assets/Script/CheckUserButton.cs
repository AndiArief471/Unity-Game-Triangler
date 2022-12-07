using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckUserButton : MonoBehaviour
{
    public Text input;
    CheckUser CheckUserScript;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserLoginCheck(){
        //string text = input.ToString();
        //CheckUserScript.ReadNameInput(text);
    }

    /*
    public void confirmUser(){
        if(!usernameIsExist){
            NewPlayer.SetActive(true);
            Form.SetActive(false);
        }else{
            UserPassword.SetActive(true);
            NewText.text = "Welcome Back, Please Confirm Your Password";
        }
    }
    */
}
