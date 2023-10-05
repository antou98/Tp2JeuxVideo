using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{

    public Rigidbody rigidbody;

    public float moveSpeed = 0.000001f;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveToPlayer();
    }

    public void moveToPlayer(){
        
        Vector3 directionPlayer = PlayerController.player.transform.transform.position - transform.position;
        rigidbody.AddForce(directionPlayer* moveSpeed*Time.deltaTime, ForceMode.Impulse);
        
    }
}
