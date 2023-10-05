using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelControler : MonoBehaviour
{
    public static LevelControler instance;

    public GameObject gameObject;

    private EnemyController enemyController;

    public GameObject powerUp;

    public GameObject vueFinal;

    public bool isGameOver = false;

    private int zMin = -10;

    private int zMax = 10;

    private int xMax = 7;

    private int xMin = -7;

    public int niveauDifficulte = 0;

    public int nbBadGuysDefaut= 2;

    public int nombreBadGuysActuel;
    void Start()
    {
        vueFinal.SetActive(false);
        enemyController =GetComponent<EnemyController>();
        instance = this;
        InitializeEnemy();
        spawnPowerUp();
        
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
            InstantiateRandomSquare(gameObject);
        }
    }

    public void EnemyOutOfBound() {  
        if(!isGameOver){
        nombreBadGuysActuel--;
        if(nombreBadGuysActuel==0){
            niveauDifficulte++;
            InitializeEnemy();
            spawnPowerUp();
        }}
    }

    public void GameOver() { 
        isGameOver = true;
        vueFinal.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void spawnPowerUp(){
        InstantiateRandomSquare(powerUp);
    }

    public void InstantiateRandomSquare(GameObject gameObjectToInstanciate){
        System.Random random = new System.Random();
        int zRand = random.Next(zMin,zMax);
        int xRand = random.Next(xMin,xMax);
        Instantiate(gameObjectToInstanciate,new Vector3(xRand,0f,zRand),Quaternion.identity);
    }
}
