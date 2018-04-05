using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour {
    float yTransform = 0.5f;
    float xTransform = 0.5f;
    float maxY;
    float minY;
    float maxX;
    float minX;
    float speed = 7;
    private System.Random randomTransformChange;
    public static bool dead;

    void Start ()
    {
        moveEnemy.dead = false;
        Vector3 playerHalfSize = 0.5f * transform.localScale;
        CalculateScreenBounds.calculate();
        maxY = CalculateScreenBounds.distanceToVerticalBoundOfView - playerHalfSize.y;
        minY = -CalculateScreenBounds.distanceToVerticalBoundOfView + playerHalfSize.y;
        maxX = CalculateScreenBounds.distanceToHorizontalBoundOfView - playerHalfSize.x;
        minX = CalculateScreenBounds.distanceToHorizontalBoundOfView / 8f + playerHalfSize.x;
    }
	
	void Update ()
    {
        if (moveEnemy.dead)
        {
            return;
        }
        Vector3 currentPosition = transform.position;
        //randomTransformChange = new System.Random();
        //int shouldChange = randomTransformChange.Next(0, 200);
        //if (shouldChange == 0)
        //{
        //    yTransform = -yTransform;
        //}
        if (currentPosition.y >= maxY || currentPosition.y <=minY)
        {   
            yTransform = -yTransform;
        }
        Vector3 moveVert = new Vector3(0, yTransform, 0);
        transform.Translate(moveVert * Time.deltaTime * speed);

        if (currentPosition.x >= maxX || currentPosition.x <= minX)
        {
            xTransform = -xTransform;
        }
        Vector3 moveHor = new Vector3(xTransform, 0, 0);
        transform.Translate(moveHor * Time.deltaTime * speed);

    }
}
