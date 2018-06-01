using UnityEngine;

/// <summary>
/// Class responsible for movement of bonus (side, speed).
/// </summary>
public class BonusMovement : MonoBehaviour {

    /// <summary>
    /// Speed of bonus movement.
    /// </summary>
    public float speed;
    /// <summary>
    /// Side of bonus movement.
    /// </summary>
    private Side side;
    private System.Random random = new System.Random();
    /// <summary>
    ///Vector of bonus movement.
    /// </summary>
    private Vector3 movementVector;

    /// <summary>
    /// Initialization of movemet side.
    /// </summary>
    void Start () {
        ranomizeBonusMovementSide();    
    }

    /// <summary>
    /// Randomize bonus movement. It will move either to the left side or the right one.
    /// </summary>
    private void ranomizeBonusMovementSide()
    {
        CalculateScreenBounds.calculate();
        int sideRand = random.Next(0, 2);
        if (sideRand == 0)
        {
            side = Side.Left;
            movementVector = new Vector3(-0.5f, 0, 0);
        }
        else
        {
            side = Side.Right;
            movementVector = new Vector3(0.5f, 0, 0);
        }
    }

    /// <summary>
    /// Translates the positionof bonus. If bonus is outside the screen, it will be destroyed.
    /// </summary>
    void Update () {
        transform.Translate(movementVector * Time.deltaTime * speed, Camera.main.transform);      
        if (!isInWindow())
            Destroy(gameObject);
    }
    /// <summary>
    /// Checks if the bullet is in the window.
    /// </summary>
    /// <returns><c>true</c>, if in window was ised, <c>false</c> otherwise.</returns>
    bool isInWindow()
    {
        if (transform.position.x > CalculateScreenBounds.distanceToHorizontalBoundOfView)
            return false;
        if (transform.position.x < CalculateScreenBounds.distanceToHorizontalBoundOfView * (-1))
            return false;
        return true;
    }
}
