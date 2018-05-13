using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public float moveVertical;
	public float moveHorizontal;
	public float WidthOfMovement;
	public Side side;


	private float maxY;
	private float minY;
	private float maxX;
	private float minX;
	// Use this for initialization
	void Start ()
	{
		Vector3 playerHalfSize = WidthOfMovement * transform.localScale;
		CalculateScreenBounds.calculate();
		if (side == Side.Left) {
			maxY = CalculateScreenBounds.distanceToVerticalBoundOfView - playerHalfSize.y;
			minY = -CalculateScreenBounds.distanceToVerticalBoundOfView + playerHalfSize.y;
			maxX = -CalculateScreenBounds.distanceToHorizontalBoundOfView / 8f - playerHalfSize.x;
			minX = -CalculateScreenBounds.distanceToHorizontalBoundOfView + playerHalfSize.x;
		} else {
			maxY = CalculateScreenBounds.distanceToVerticalBoundOfView - playerHalfSize.y;
			minY = -CalculateScreenBounds.distanceToVerticalBoundOfView + playerHalfSize.y;
			maxX = CalculateScreenBounds.distanceToHorizontalBoundOfView - playerHalfSize.x;
			minX = CalculateScreenBounds.distanceToHorizontalBoundOfView / 8f + playerHalfSize.x;
		}
	}
	
	void FixedUpdate(){

		Vector3 verticalMove = new Vector3(0, moveVertical, 0);
		Vector3 horizontalMove = new Vector3(moveHorizontal, 0, 0);
		Vector3 currentPosition = transform.position;

		if ((currentPosition.y <= maxY || verticalMove.y < 0) && (currentPosition.y >= minY || verticalMove.y > 0))
		{
			transform.Translate(verticalMove * Time.deltaTime * gameObject.GetComponent<PlayerAttributes>().speed);
		}
		if ((currentPosition.x <= maxX || horizontalMove.x < 0) && (currentPosition.x >= minX || horizontalMove.x > 0))
		{
			transform.Translate(horizontalMove * Time.deltaTime * gameObject.GetComponent<PlayerAttributes>().speed);
		}
	}
}

