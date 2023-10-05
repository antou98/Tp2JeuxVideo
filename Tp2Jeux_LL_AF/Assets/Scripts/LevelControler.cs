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

    public int niveauDifficulte = 0;

    public int nbBadGuysDefaut= 2;

    public int nombreBadGuysActuel;
    void Start()
    {
        enemyController =GetComponent<EnemyController>();
        instance = this;
        InitializeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeEnemy()
    {
        int nbBadGuys = nbBadGuysDefaut+niveauDifficulte;
        nombreBadGuysActuel = nbBadGuys;

        for(int i = 0;i<nbBadGuys;i++){
            System.Random random = new System.Random();
            int zRand = random.Next(zMin,zMax);
            int xRand = random.Next(xMin,xMax);
            Instantiate(gameObject,new Vector3(xRand,1f,zRand),Quaternion.identity);
        }   
    }

    public void EnemyOutOfBound() {  
        nombreBadGuysActuel--;
        if(nombreBadGuysActuel==0){
            niveauDifficulte++;
            InitializeEnemy();
        }
    }

    public void GameOver() { 

    }
}
