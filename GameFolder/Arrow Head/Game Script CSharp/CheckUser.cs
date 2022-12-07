using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CheckUser : MonoBehaviour
{
    public InputField UserInput;
    public InputField PassInput;
    public Text ErrorMessage;
    public Button ConfirmButton;
    public GameObject NewPlayerUI;

    public void OnLoginButtonClicked(){
        ConfirmButton.interactable = false;
        StartCoroutine(NameInput());
    }

    public void GetUsername(string user){
        CameraMovement.Username = user;
        SceneManager.LoadScene("GameScene");
    }

    public void InputNewUser(){
        AddUser(UserInput.text, PassInput.text);
        GetUsername(UserInput.text);
    }

    public IEnumerator NameInput(){
        WWWForm form = new WWWForm();
        form.AddField("addUsername", UserInput.text);
        form.AddField("addPassword", PassInput.text);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ArrowHeadDB/checkUser.php", form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError){
                ErrorMessage.text = "404 not found";
            }
            else{
                if(www.downloadHandler.text == "Invalid Credentials"){
                    ErrorMessage.text = "Invalid Credentials";
                }else if(www.downloadHandler.text == "Username Doesnt Exist"){
                    NewPlayerUI.SetActive(true);
                }
                else{
                    Debug.Log(www.downloadHandler.text);
                    GetUsername(UserInput.text);
                }
            }
        }
        ConfirmButton.interactable = true;
    }

    public void AddUser(string User, string Pass){
        WWWForm NewPForm = new WWWForm();
        NewPForm.AddField("addUsername", User);
        NewPForm.AddField("addPassword", Pass);
        WWW web = new WWW("http://localhost/ArrowHeadDB/NewUser.php", NewPForm);
    }

    //string URL = "http://localhost/ArrowHeadDB/checkUser.php";
    //public string [] usersData;

    //public bool userCheck = true;

    //private string input;
    /*
    bool usernameIsExist = false;

    public GameObject NewPlayer;
    public GameObject Form;
    public GameObject UserPassword;
    public Text NewText;

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
