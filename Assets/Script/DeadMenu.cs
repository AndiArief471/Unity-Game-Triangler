using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class DeadMenu : MonoBehaviour
{
    LivesSystem LivesSystemScript;
    GameTime GameTimeScript;
    KillCounter KillCounterScript;
    CameraMovement CameraMovementScript;
    Shooting ShootingScript;

    public GameObject DeadMenuUI;
    public Text TotalTime;
    public Text scoreText;
    string TimeGet;
    int TotalScore;
    string HighScoreString;
    int HighScoreInt = 0;

    public void Start(){
        LivesSystemScript = GameObject.Find("Player").GetComponent<LivesSystem>();
        GameTimeScript = GameObject.Find("Main Camera").GetComponent<GameTime>();
        CameraMovementScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        KillCounterScript = GameObject.Find("KillCount").GetComponent<KillCounter>();
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(LivesSystemScript.dead){
            Dead();
        }
    }
    public void Dead(){
        DeadMenuUI.SetActive(true);
        Time.timeScale = 0f;
        TimeGet = GameTimeScript.currentTimeText.text;
        TotalTime.text = TimeGet;

        TotalScore = GameTimeScript.score * KillCounterScript.kills;
        scoreText.text = TotalScore.ToString();

        StartCoroutine(Highscore());
        if(HighScoreString == "User ID Not Found"){
            AddScoreboard(CameraMovementScript.UserId, CameraMovementScript.UsernameToPass, TotalScore);
        }
        else{
            HighScoreInt = Convert.ToInt32(HighScoreString);
            if(TotalScore > HighScoreInt){
                UpdateScore(CameraMovementScript.UserId, TotalScore);
            }
        }
    }

    public void AddScoreboard(string userId,string username, int score){
        WWWForm form = new WWWForm();
        form.AddField("addUserId", userId);
        form.AddField("addUsername", username);
        form.AddField("addScore", score);
        WWW www = new WWW("http://localhost/ArrowHeadDB/inputScoreboard.php", form);
    }

    public IEnumerator Highscore(){
        WWWForm form = new WWWForm();
        form.AddField("addUserId", CameraMovementScript.UserId);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ArrowHeadDB/HighScoreCheck.php", form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError){
                Debug.Log("404 not found");
            }
            else{
                HighScoreString = www.downloadHandler.text;
            }
        }
    }

    public void UpdateScore(string userId, int score){
        WWWForm form = new WWWForm();
        form.AddField("addUserId", userId);
        form.AddField("addScore", score);
        WWW www = new WWW("http://localhost/ArrowHeadDB/UpdateScore.php", form);
    }
}
