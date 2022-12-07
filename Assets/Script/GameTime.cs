using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTime : MonoBehaviour
{
    bool gameTimeStop = false;
    public float currentTime;
    public Text currentTimeText;
    public int score;
    float multiplier = 69;

    void start(){
        currentTime = 0;
    }

    void Awake(){
        gameTimeStop = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if(gameTimeStop == true){
            currentTime = currentTime + Time.deltaTime;
        }
        score = Mathf.RoundToInt(currentTime * multiplier);
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss");
    }
}
