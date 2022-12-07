using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class CameraMovement : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    public static string Username;
    public string UserId;
    public string UsernameToPass;

    public void Start(){
        StartCoroutine(NameInput());
        UsernameToPass = Username;
    }

    public void InsertActivity(string userIdInput){
        WWWForm NewPForm = new WWWForm();
        NewPForm.AddField("addUserId", userIdInput);
        WWW web = new WWW("http://localhost/ArrowHeadDB/UserActivity.php", NewPForm);
    }

    public IEnumerator NameInput(){
        WWWForm form = new WWWForm();
        form.AddField("addUsername", Username);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ArrowHeadDB/getUserId.php", form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError){
                Debug.Log("404 not found");
            }
            else{
                UserId = www.downloadHandler.text;
                InsertActivity(UserId);
            }
        }
    }

    private void LateUpdate(){
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX){
            if(transform.position.x < lookAt.position.x){
                delta.x = deltaX - boundX;
            }
            else{
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY){
            if(transform.position.y < lookAt.position.y){
                delta.y = deltaY - boundY;
            }
            else{
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
