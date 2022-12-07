using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getUsers : MonoBehaviour
{
    string URL = "http://localhost/ssipFinal/getUsers.php";
    public string [] usersData;

    IEnumerator Start(){
        WWW users = new WWW(URL);
        yield return users;
        string userDataString = users.text;
        usersData = userDataString.Split(';');

        print(GetValueData(usersData[1],"Score:"));
    }

    string GetValueData(string data, string index){
        string value = data.Substring(data.IndexOf(index)+index.Length);
        if(value.Contains("|")){
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }
}
