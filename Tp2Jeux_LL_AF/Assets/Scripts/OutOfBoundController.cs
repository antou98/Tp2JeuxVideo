using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "Player":
                LevelControler.instance.GameOver();
                break;
            case "Enemy":
                LevelControler.instance.EnemyOutOfBound();
                Destroy(other.gameObject);
                break;
        }

    }
}
