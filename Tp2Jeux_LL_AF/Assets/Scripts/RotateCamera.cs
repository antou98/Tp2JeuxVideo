using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    
    public Camera camera;

    public GameObject gameObject;
    public float speed = 50f;

    // Update is called once per frame
    void Update()
    {
                camera.transform.RotateAround(gameObject.transform.position, 
                                         Vector3.up,
                                         -Input.GetAxis("Horizontal")*speed*Time.deltaTime); 

                                
    }
}
