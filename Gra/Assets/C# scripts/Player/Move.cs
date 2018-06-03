using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Class responsible for player movement.
/// </summary>
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
    /// <summary>
    /// List of sides on which player collides with planet.
    /// </summary>
    private List<Side> collisionSides = new List<Side>();
    /// <summary>
    /// Field describing if the player is colliding with planet.
    /// </summary>
    private bool isCollisionWithPlanet = false;
    /// <summary>
    /// Maximal vertical field of view where player can move - up side of the field.
    /// </summary>
    private float maxY;
    /// <summary>
    /// Minimal vertical field of view where player can move - down side of the field.
    /// </summary>
    private float minY;
    /// <summary>
    /// Maximal horizontal field of view where player can move - right side of the field.
    /// </summary>
    private float maxX;
    /// <summary>
    /// Minimal horizontal field of view where player can move - left side of the field.
    /// </summary>
    private float minX;

    /// <summary>
    /// Sets basic fields. Counts player half size and the limits of player movement depending on 
    /// its size and screen bounds.
    /// </summary>
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

    /// <summary>
    /// Controls player movement. If the player does not collide with his field bounds nor with any planet, 
    /// he will be moved.
    /// </summary>
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

    /// <summary>
    /// Checks if player collides with something. It this is the planet, side of the collision is added to collisionSides
    /// field. If it is bonus, player components are updated.
    /// </summary>
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
                Debug.Log(GetComponent<PlayerAttributes>().isSuperSpeed);
                Destroy(col.gameObject);
                break;
        }
    }

    /// <summary>
    /// Clears collisionSides field when player does not collide with the planet anymore.
    /// </summary>
    void OnCollisionExit(Collision col)
    {
        collisionSides.Clear();
    }
}