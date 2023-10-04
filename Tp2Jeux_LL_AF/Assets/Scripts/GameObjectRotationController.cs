using UnityEngine;

public class GameObjectRotationController : MonoBehaviour
{

    public float rotationSpeed = 90.0f;

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Faire tourner l'objet autour de l'axe Y
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
