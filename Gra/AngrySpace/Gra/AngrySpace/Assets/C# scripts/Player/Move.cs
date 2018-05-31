using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    /// <summary>
    /// The move vertical.
    /// </summary>
    public float moveVertical;
    /// <summary>
    /// The move horizontal.
    /// </summary>
    public float moveHorizontal;
    /// <summary>
    /// The width of movement.
    /// </summary>
    public float WidthOfMovement;
    /// <summary>
    /// The side.
    /// </summary>
    public Side side;

    private List<Side> collisionSides = new List<Side>();
    private bool isCollisionWithPlanet = false;
    private float maxY;
    private float minY;
    private float maxX;
    private float minX;
    // Use this for initialization
    void Start()
    {
        Vector3 playerHalfSize = WidthOfMovement * transform.localScale;
        CalculateScreenBounds.calculate();
        if (side == Side.Left)
        {
            maxY = CalculateScreenBounds.distanceToVerticalBoundOfView - playerHalfSize.y;
            minY = -CalculateScreenBounds.distanceToVerticalBoundOfView + playerHalfSize.y;
            maxX = -CalculateScreenBounds.distanceToHorizontalBoundOfView / 2f - playerHalfSize.x;
            minX = -CalculateScreenBounds.distanceToHorizontalBoundOfView + playerHalfSize.x;
        }
        else
        {
            maxY = CalculateScreenBounds.distanceToVerticalBoundOfView - playerHalfSize.y;
            minY = -CalculateScreenBounds.distanceToVerticalBoundOfView + playerHalfSize.y;
            maxX = CalculateScreenBounds.distanceToHorizontalBoundOfView - playerHalfSize.x;
            minX = CalculateScreenBounds.distanceToHorizontalBoundOfView / 2f + playerHalfSize.x;
        }
    }

    void FixedUpdate()
    {

        Vector3 verticalMove = new Vector3(0, moveVertical, 0);
        Vector3 horizontalMove = new Vector3(moveHorizontal, 0, 0);
        Vector3 currentPosition = transform.position;
        if ((verticalMove.y < 0 || (currentPosition.y <= maxY && !collisionSides.Contains(Side.Up))) && (verticalMove.y > 0 || (currentPosition.y >= minY && !collisionSides.Contains(Side.Down))))
        {
            transform.Translate(verticalMove * Time.deltaTime * gameObject.GetComponent<PlayerAttributes>().speed);
        }
        if ((horizontalMove.x < 0 || (currentPosition.x <= maxX && !collisionSides.Contains(Side.Right))) && (horizontalMove.x > 0 || (currentPosition.x >= minX && !collisionSides.Contains(Side.Left))))
        {
            transform.Translate(horizontalMove * Time.deltaTime * gameObject.GetComponent<PlayerAttributes>().speed);
        }
    }

    void OnCollisionStay(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "Planet":
                GameObject planet = col.gameObject;
                if (transform.position.x >= planet.transform.position.x)
                    if (!collisionSides.Contains(Side.Left))
                        collisionSides.Add(Side.Left);
                if (transform.position.x <= planet.transform.position.x)
                    if (!collisionSides.Contains(Side.Right))
                        collisionSides.Add(Side.Right);
                if (transform.position.y >= planet.transform.position.y)
                    if (!collisionSides.Contains(Side.Down))
                        collisionSides.Add(Side.Down);
                if (transform.position.y <= planet.transform.position.y)
                    if (!collisionSides.Contains(Side.Up))
                        collisionSides.Add(Side.Up);
                break;
            case "BonusLife":
                gameObject.GetComponent<PlayerAttributes>().IncrementLives();
                Destroy(col.gameObject);
                break;
            case "BonusFastShots":
                GetComponent<PlayerAttributes>().isSuperSpeed = true;
                Destroy(col.gameObject);
                break;
        }

    }

    void OnCollisionExit(Collision col)
    {
        collisionSides.Clear();
    }
}