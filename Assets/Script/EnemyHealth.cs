using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    void Start(){
        health = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 1){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Bullet"){
            health -= 20;
            Destroy(target.gameObject);
        }
        
    }
}
