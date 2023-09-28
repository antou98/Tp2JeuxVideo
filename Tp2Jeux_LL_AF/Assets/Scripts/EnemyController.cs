using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{


    /*private int zMin = -10;

    private int zMax = 10;

    private int xMax = 7;

    private int xMin = -7;*/

    public Rigidbody rigidbody;

    public float moveSpeed = 0.000001f;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        moveToPlayer();
    }

    public void moveToPlayer(){
        
        Vector3 directionPlayer = PlayerController.player.transform.transform.position - transform.position;
        //transform.Translate(directionPlayer * moveSpeed*Time.deltaTime);
        rigidbody.AddForce(directionPlayer* moveSpeed*Time.deltaTime, ForceMode.Impulse);
        
    }
   /* public void InitializeEnemy(GameObject gameObject)
    {
        System.Random random = new System.Random();
        int zRand = random.Next(zMin,zMax);
        int xRand = random.Next(xMin,xMax);
        Instantiate(gameObject,new Vector3(xRand,1f,zRand),Quaternion.identity);
    }*/
    
}
