using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static GameObject player;
    private Rigidbody rb;
    private PhysicMaterial physicMaterial;
    private new Camera camera;

    public float moveSpeed = 5f;
    private float defaultBounciness;

    private PowerUp.PowerupEnum? powerUpActif = null;
    private float tempsRestantPowerUp = 0 ;

    // Start is called before the first frame update
    void Start()
    {

        player = gameObject;
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        physicMaterial = GetComponent<PhysicMaterial>();
    }

    // Update is called once per frame
    void Update()
    {

        //Decrementer temps powerup et effets
        if (powerUpActif is not null)
        {
            if (tempsRestantPowerUp > 0)
            {
                tempsRestantPowerUp -= Time.deltaTime;
            }
            else {

                //On desactive le powerup
                switch (powerUpActif) {

                    case PowerUp.PowerupEnum.BOUNCE:
                        physicMaterial.bounciness = defaultBounciness;
                        break;
                    case PowerUp.PowerupEnum.SIZE:
                        transform.localScale = Vector3.one * 0.5f;
                        break;
                    case PowerUp.PowerupEnum.COLLIDEABLE:
                        gameObject.GetComponent<Collider>().enabled = true;
                        break;
                }

                powerUpActif = null;
            }
        }

    }

    /// <summary>
    /// Update physiques du joueur
    /// </summary>
    private void FixedUpdate()
    {
        //Deplacer le joueur vers l avant ou l arriere, selon la physique
        rb.AddForce((camera.transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime), ForceMode.Impulse);
    }

    /// <summary>
    /// Fonction appellee lorsque l'on ramasse un powerup
    /// </summary>
    /// <param name="powerUp"></param>
    public void EnablePowerUp(PowerUp.PowerupEnum powerUp)
    {

        //On empeche d avoir 2 powerups a la fois
        if (powerUpActif is not null) {

            //Initialisation powerUp
            powerUpActif = powerUp;

            switch (powerUpActif)
            {
                case PowerUp.PowerupEnum.BOUNCE:
                    defaultBounciness = physicMaterial.bounciness;
                    physicMaterial.bounciness = 0.2f;
                    tempsRestantPowerUp = 15;
                    break;
                case PowerUp.PowerupEnum.SIZE:
                    transform.localScale = Vector3.one * 2;
                    tempsRestantPowerUp = 10;
                    break;
                case PowerUp.PowerupEnum.COLLIDEABLE:
                    gameObject.GetComponent<Collider>().enabled = false;
                    tempsRestantPowerUp = 4;
                    break;
            }
        }
    }
}
