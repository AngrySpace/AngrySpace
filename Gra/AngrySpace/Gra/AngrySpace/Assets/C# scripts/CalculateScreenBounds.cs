using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateScreenBounds : MonoBehaviour {

    public static float distanceToVerticalBoundOfView;
    public static float distanceToHorizontalBoundOfView;



    public static void calculate()
    {
        float fieldOfView = Camera.main.fieldOfView;
        float radius = Camera.main.transform.position.z;
        radius = -radius; //because "z" coordinate of main camera is negative
        float tanFieldOfView = Mathf.Tan(30 * Mathf.Deg2Rad);
        distanceToVerticalBoundOfView = tanFieldOfView * radius;
        distanceToHorizontalBoundOfView = distanceToVerticalBoundOfView * Screen.width / Screen.height;


    }	
}
