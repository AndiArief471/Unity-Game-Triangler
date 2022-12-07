using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insertUser : MonoBehaviour
{
    string URL = "http://localhost/ssipFinal/insertUser.php";
    public string InputUserId, InputUsername, InputScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            AddUser(InputUserId, InputUsername, InputScore);
        }
    }

    public void AddUser(string userId,string username, string score){
        WWWForm form = new WWWForm();
        form.AddField("addUserId", userId);
        form.AddField("addUsername", username);
        form.AddField("addScore", score);
        WWW www = new WWW(URL, form);
    }
}
