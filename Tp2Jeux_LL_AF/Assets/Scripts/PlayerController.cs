using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static GameObject player;
    private Rigidbody rb;
    private PhysicMaterial physicMaterial;

    public float moveSpeed = 5f;

    private float powerUpstartTime = 0;
    private float powerUpCurrentTime = 0 ;
    private Boolean powerUpActif = false ;

    // Start is called before the first frame update
    void Start()
    {

        player = gameObject;
        rb = GetComponent<Rigidbody>();
        physicMaterial = GetComponent<PhysicMaterial>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Deplacer le joueur vers l avant ou l arriere, selon la physique
        rb.AddForce(new Vector3(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime), ForceMode.Impulse);
    }

    /// <summary>
    /// Fonction appellee lorsque l'on ramasse un powerup
    /// </summary>
    /// <param name="powerUp"></param>
    public void EnablePowerUp(PowerupEnum powerUp)
    {

        powerUpstartTime = Time.time;
        powerUpActif = true;

        switch (powerUp)
        {
            case PowerupEnum.BOUNCE:
                break;
            case PowerupEnum.SIZE:
                break;
            case PowerupEnum.COLLIDEABLE:
                break;
        }
    }


    /// <summary>
    /// Les powerup disponibles
    /// </summary>
    public enum PowerupEnum { 
    
        BOUNCE,
        SIZE,
        COLLIDEABLE

    }
}
