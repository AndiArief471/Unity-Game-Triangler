using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text counterText;
    public Text TotalKill;
    public int kills;

    // Update is called once per frame
    void Update()
    {
        ShowKill();
    }

    private void ShowKill(){
        counterText.text = kills.ToString();
        TotalKill.text = kills.ToString();
    }

    public void AddKill(){
        kills++;
    }
}
