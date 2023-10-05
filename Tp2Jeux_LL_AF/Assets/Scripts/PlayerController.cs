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

    Material playerMat;

    public float dureePulsion1 = 0.1f;
    public float dureePulsion2 = 0.6f;

    private AudioSource playerAudioSource;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        //Setup des attributs
        player = gameObject;
        camera = Camera.main;

        //Audio
        playerAudioSource = player.GetComponent<AudioSource>();

        //Physique
        rb = GetComponent<Rigidbody>();
        physicMaterial = GetComponent<SphereCollider>().material;

        //Mat
        playerMat = GetComponent<MeshRenderer>().material;
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

                //On desactive le powerup et ses visuels
                switch (powerUpActif) {

                    case PowerUp.PowerupEnum.BOUNCE:
                        physicMaterial.bounciness = defaultBounciness;
                        playerMat.SetInt("_BouncePU", 0);
                        break;
                    case PowerUp.PowerupEnum.SIZE:
                        transform.localScale = Vector3.one;
                        playerMat.SetFloat("_ScrollDirection", 1f);
                        break;
                    case PowerUp.PowerupEnum.COLLIDEABLE:
                        gameObject.GetComponent<SphereCollider>().enabled = true;
                        rb.constraints = rb.constraints & ~RigidbodyConstraints.FreezePositionY;
                        playerMat.SetInt("_Invisibilite", 0);
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
        if (powerUpActif is null) {

            //Initialisation powerUp
            powerUpActif = powerUp;

            //On active les powerups et leur visuels
            switch (powerUpActif)
            {
                case PowerUp.PowerupEnum.BOUNCE:
                    defaultBounciness = physicMaterial.bounciness;
                    physicMaterial.bounciness = 0.2f;
                    tempsRestantPowerUp = 15;
                    playerMat.SetInt("_BouncePU", 1);
                    break;
                case PowerUp.PowerupEnum.SIZE:
                    transform.localScale = Vector3.one * 2;
                    tempsRestantPowerUp = 10;
                    playerMat.SetFloat("_ScrollDirection", 0.3f);
                    break;
                case PowerUp.PowerupEnum.COLLIDEABLE:
                    gameObject.GetComponent<SphereCollider>().enabled = false;
                    rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;
                    tempsRestantPowerUp = 4;
                    playerMat.SetInt("_Invisibilite", 1);
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //On touche un enemy
        if (collision.gameObject.tag.Equals("Enemy", StringComparison.InvariantCultureIgnoreCase)) {
            playerAudioSource.PlayOneShot(hitSound);
            StartCoroutine(pulsionJoueur());
        }
    }

    /// <summary>
    /// Pulse le joueur vers le rouge
    /// </summary>
    /// <returns></returns>
    private IEnumerator pulsionJoueur() {
        float tempsPasse = 0;

        while (tempsPasse < dureePulsion1)
        {
            float progression = tempsPasse / dureePulsion1;
            playerMat.SetFloat("_Scroll", Mathf.Lerp(0f, 1f, progression));
            tempsPasse += Time.deltaTime;
            yield return null;
        }

        // Réinitialiser la couleur
        StartCoroutine(ArretPulsionJoueur());
    }

    /// <summary>
    /// Arrete le pulse du joueur
    /// </summary>
    /// <returns></returns>
    private IEnumerator ArretPulsionJoueur()
    {
        float tempsPasse = 0;

        while (tempsPasse < dureePulsion2)
        {
            float progression = tempsPasse / dureePulsion2;
            playerMat.SetFloat("_Scroll", Mathf.Lerp(1f, 0f, progression));
            tempsPasse += Time.deltaTime;
            yield return null;
        }
    }
}