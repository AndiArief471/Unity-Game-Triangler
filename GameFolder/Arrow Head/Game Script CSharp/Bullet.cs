using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision){
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponent<Enemies>().TakeDamage();
        }
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    /*
    void OnTriggerEnter2D(Collider2D hit){
        if(hit.CompareTag("Enemy")){
            hit.gameObject.GetComponent<Enemies>().TakeDamage();
        }
    }
    */
}
