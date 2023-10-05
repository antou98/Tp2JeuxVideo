using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rigidbody;
    private PhysicMaterial physicMaterial;
    private Material ennemyMat;

    public float moveSpeed = 0.000001f;

    // Start is called before the first frame update
    void Start()
    {
        physicMaterial = GetComponent<SphereCollider>().material;
        ennemyMat = GetComponent<MeshRenderer>().material;

        InitializeEnemy();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveToPlayer();
    }

    public void InitializeEnemy() {
        int difficulte = LevelControler.instance.niveauDifficulte;

        // Set mat ennemi selon difficulte
        ennemyMat.SetFloat("_Difficulte", difficulte);

        // Set de la physique
        physicMaterial.bounciness = Mathf.Clamp(difficulte,1,10)/10;
        float sizeActuel = Mathf.Lerp(1,3, Mathf.Clamp(difficulte, 1, 10)/10.0f);
        transform.localScale = new Vector3(sizeActuel,sizeActuel, sizeActuel);
    }

    public void moveToPlayer(){
        Vector3 directionPlayer = PlayerController.player.transform.transform.position - transform.position;
        directionPlayer.y = 0f;
        rigidbody.AddForce(directionPlayer* moveSpeed*Time.deltaTime, ForceMode.Impulse);
    }
}
