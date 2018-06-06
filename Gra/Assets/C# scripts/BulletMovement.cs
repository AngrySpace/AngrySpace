using UnityEngine;

/// <summary>
/// Class representing the movement of the bullet and it's reaction to the collision,
/// which is rotating around colliding planet.
/// </summary>
public class BulletMovement : MonoBehaviour
{
	/// <summary>
	/// The x direction coeffcient.
	/// </summary>
	public int xDirectionCoeffcient;
	/// <summary>
	/// The speed.
	/// </summary>
	public float speed = 500;
    /// <summary>
	/// Vector of bullet movement.
	/// </summary>
	private Vector3 shootCurrent;
    /// <summary>
	/// The speed of rotation around planet in degrees per second.
	/// </summary>
	private float rotationSpeed = 100.0f;
    /// <summary>
	/// Planet the bullet is colliding with.
	/// </summary>
	private GameObject planet;
    /// <summary>
	/// Planet the bullet is colliding with.
	/// </summary>
	private const string planetTag = "Planet";

    /// <summary>
	/// Initializes bounds of view and the movement vector.
	/// </summary>
	void Start ()
	{
		CalculateScreenBounds.calculate ();
		shootCurrent = new Vector3 (xDirectionCoeffcient * 0.5f, 0, 0);
	}

	/// <summary>
	/// Update this bullet.
	/// The rotate and
	/// if it is out of window destroy object
	/// </summary>
	void Update ()
	{
		transform.Translate (speed * Time.deltaTime * shootCurrent);
		if (!isInWindow ())
			Destroy (gameObject);		
	}
    /// <summary>
    /// check if the bullet is in the window
    /// </summary>
    /// <returns><c>true</c>, if in window was ised, <c>false</c> otherwise.</returns>
    private bool isInWindow ()
	{
		if (transform.position.x > CalculateScreenBounds.distanceToHorizontalBoundOfView)
			return false;
		if (transform.position.x < CalculateScreenBounds.distanceToHorizontalBoundOfView * (-1))
			return false;
		if (transform.position.y > CalculateScreenBounds.distanceToVerticalBoundOfView)
			return false;
		if (transform.position.y < CalculateScreenBounds.distanceToVerticalBoundOfView * (-1))
			return false;

		return true;	
	}
	/// <summary>
	/// the rotating movement on collision with planet
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionStay (Collision col)
	{
		if (col.gameObject.CompareTag(planetTag)) {
			planet = col.gameObject;
			Vector3 direction;
			if (transform.position.y > planet.transform.position.y)
				if (xDirectionCoeffcient > 0)
					direction = Vector3.back;
				else
					direction = Vector3.forward;
				else if (xDirectionCoeffcient < 0)
					direction = Vector3.back;
				else
					direction = Vector3.forward;
			
			transform.RotateAround (planet.transform.position, direction, rotationSpeed * Time.deltaTime);
		}
	}
}
