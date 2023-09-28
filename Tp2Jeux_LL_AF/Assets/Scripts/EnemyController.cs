using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject gameObjectEnemy;

    private int zMin = -10;

    private int zMax = 10;

    private int xMax = 7;

    private int xMin = -7;

    // Start is called before the first frame update
    void Start()
    {
        InitializeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeEnemy()
    {
    //level va venir de levelcontroller
    int level = 2;
    for(int i = 0;i<level;i++){
        System.Random random = new System.Random();
        int zRand = random.Next(zMin,zMax);
        int xRand = random.Next(xMin,xMax);
        Instantiate(gameObjectEnemy,new Vector3(xRand,1f,zRand),Quaternion.identity);
        }
        
    }
}
