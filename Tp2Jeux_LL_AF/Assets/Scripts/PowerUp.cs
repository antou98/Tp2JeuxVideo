using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private PlayerController playerController;
    private PowerupEnum powerupActuel;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerController.player.GetComponent<PlayerController>();

        //changer aleatoirement
        powerupActuel = PowerupEnum.COLLIDEABLE;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player",System.StringComparison.InvariantCultureIgnoreCase)) {
            playerController.EnablePowerUp(powerupActuel);
        }

        //On detruit le powerup
        Destroy(gameObject);
    }

    /// <summary>
    /// Les powerup disponibles
    /// </summary>
    public enum PowerupEnum
    {
        BOUNCE,
        SIZE,
        COLLIDEABLE
    }
}
