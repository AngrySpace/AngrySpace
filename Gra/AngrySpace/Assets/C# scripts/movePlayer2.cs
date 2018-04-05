using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer2 : MonoBehaviour
{
    float maxY;
    float minY;
    float maxX;
    float minX;
    float speed = 12;

    void Start()
    {
        Vector3 playerHalfSize = 0.5f * transform.localScale;
        CalculateScreenBounds.calculate();
        maxY = CalculateScreenBounds.distanceToVerticalBoundOfView - playerHalfSize.y;
        minY = -CalculateScreenBounds.distanceToVerticalBoundOfView + playerHalfSize.y;
        maxX = CalculateScreenBounds.distanceToHorizontalBoundOfView - playerHalfSize.x;
        minX = CalculateScreenBounds.distanceToHorizontalBoundOfView / 8f + playerHalfSize.x;
    }
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical2");
        float moveHorizontal = Input.GetAxis("Horizontal2");
        Vector3 verticalMove = new Vector3(0, moveVertical, 0);
        Vector3 horizontalMove = new Vector3(moveHorizontal, 0, 0);
        Vector3 currentPosition = transform.position;

        if ((currentPosition.y <= maxY || moveVertical < 0) && (currentPosition.y >= minY || moveVertical > 0))
        {
            transform.Translate(verticalMove * Time.deltaTime * speed);
        }
        if ((currentPosition.x <= maxX || moveHorizontal < 0) && (currentPosition.x >= minX || moveHorizontal > 0))
        {
            transform.Translate(horizontalMove * Time.deltaTime * speed);
        }
    }
}
