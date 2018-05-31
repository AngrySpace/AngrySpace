using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour {

    public float speed;
    private Side side;
    private System.Random random = new System.Random();
    private Vector3 movementVector;
    // Use this for initialization
    void Start () {
        Debug.Log("new bonus created!");
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
	
	// Update is called once per frame
	void Update () {
        Debug.Log(movementVector);
        transform.Translate(movementVector * Time.deltaTime * speed, Camera.main.transform);      
        if (!isInWindow())
            Destroy(gameObject);
    }
    /// <summary>
    /// check if the bullet is in the window
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
