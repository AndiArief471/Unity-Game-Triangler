using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    public GameObject[] heart;
    public int life;
    public bool dead;

    // Update is called once per frame
    private void Start()
    {
        life = heart.Length;
        dead = false;
    }

    public void TakeDamage(){
        if(life >= 1){
            life -= 1;
            Destroy(heart[life].gameObject);
            if(life < 1){
                dead = true;
            }
        }  
    }
    
}
