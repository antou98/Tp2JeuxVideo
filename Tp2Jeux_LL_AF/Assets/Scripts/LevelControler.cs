using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    public static LevelControler instance;

    public GameObject gameObject;
    private EnemyController enemyController;

    private int zMin = -10;

    private int zMax = 10;

    private int xMax = 7;

    private int xMin = -7;
    void Start()
    {
        enemyController =GetComponent<EnemyController>();
        int level = 2;
        for(int i = 0;i<level;i++){
            InitializeEnemy();
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeEnemy()
    {
        System.Random random = new System.Random();
        int zRand = random.Next(zMin,zMax);
        int xRand = random.Next(xMin,xMax);
        Instantiate(gameObject,new Vector3(xRand,1f,zRand),Quaternion.identity);
    }

    public void EnemyOutOfBound() { 
        
    }

    public void GameOver() { 

    }
}
