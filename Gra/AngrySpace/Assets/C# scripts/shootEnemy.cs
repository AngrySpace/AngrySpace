using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootEnemy : MonoBehaviour
{
    float speed = 50;
    Vector3 shootCurrent;
    float xBound;
 
    void Start()
    {
        shootCurrent = new Vector3(-0.5f, 0, 0);
        CalculateScreenBounds.calculate();
        xBound = -CalculateScreenBounds.distanceToHorizontalBoundOfView;
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * shootCurrent);
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }        
    }
}
