using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;
    public float health = 5;
    
    public Transform target;

    KillCounter killCounterScript;

    [SerializeField]
    private float attackTick = 1f;

    private float canAttack;
   
    // Start is called before the first frame update
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        killCounterScript = GameObject.Find("KillCount").GetComponent<KillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        canAttack += Time.deltaTime;

        if(health <= 0){
            Die();
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            if(attackTick <= canAttack){
                collision.gameObject.GetComponent<LivesSystem>().TakeDamage();
                canAttack = 0f;
            }
            Destroy(gameObject);

        }
        //if(collision.gameObject.tag == "Bullet"){
        //    Destroy(gameObject);
        //}
    }

    public void TakeDamage(){
        health -= 5;
    }
    public void Die(){
        Destroy(gameObject);
        killCounterScript.AddKill();
    }
}
