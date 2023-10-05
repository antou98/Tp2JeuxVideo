using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    //private PlayerController playerController;
    private PowerupEnum powerupActuel;

    // Start is called before the first frame update
    void Start()
    {
        //changer aleatoirement
        int randomPowerup = Random.Range(0, 3);
        switch (randomPowerup) {
            case 0:
                powerupActuel = PowerupEnum.BOUNCE;
                transform.Find("PowerBounce").GameObject().SetActive(true);
                break;
            case 1:
                powerupActuel = PowerupEnum.SIZE;
                transform.Find("PowerSize").GameObject().SetActive(true);
                break;
            default:
                powerupActuel = PowerupEnum.COLLIDEABLE;
                transform.Find("PowerCollid").GameObject().SetActive(true);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player",System.StringComparison.InvariantCultureIgnoreCase)) {
            PlayerController.player.GetComponent<PlayerController>().EnablePowerUp(powerupActuel);

            //On detruit le powerup
            Destroy(gameObject);
        }
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
