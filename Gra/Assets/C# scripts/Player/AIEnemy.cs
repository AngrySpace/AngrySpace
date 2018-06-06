using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// AI enemy class
/// </summary>
public class AIEnemy : MonoBehaviour
{
	/// <summary>
	/// The chance to shoot.
	/// </summary>
	public int chanceToShoot;
	private static System.Random random = new System.Random();
    /// <summary>
    /// Number of possible directions.
    /// </summary>
    private int Directions = 8;
    /// <summary>
    /// The horizontal move.
    /// </summary>
    private int moveHorizontal;
    /// <summary>
    /// The vertical move.
    /// </summary>
    private int moveVertical;
    /// <summary>
    /// The duration between frame movement.
    /// </summary>
    private int frameMovementDuration = 0;
    /// <summary>
    /// Minimum player's speed.
    /// </summary>
    private int speedMin = 10;
    /// <summary>
    /// Maximum player's speed.
    /// </summary>
    private int speedMax = 30;
	
	/// <summary>
	/// Update the shot and movement.
	/// </summary>
	void Update ()
	{
		RandomShoot ();
		RandomMovement ();
	}
	/// <summary>
	/// Randoms the shoot.
	/// </summary>
	void RandomShoot ()
	{
		bool randomShot = random.Next (0, chanceToShoot) == 0 ? true : false;
		gameObject.GetComponent<PlayerAttributes> ().isFire = randomShot;
	}
	/// <summary>
	/// Randoms the movement.
	/// random the direction and speed
	/// </summary>
	void RandomMovement ()
	{
		if (frameMovementDuration == 0) {
			/* Pattern movement direction
		 * 1 2 3
		 * 4 x 5
		 * 6 7 8
		 */
			int direction = random.Next (1, Directions);
			//int moveHorizontal, moveVertical;
			switch (direction) {
			case 1:
				moveHorizontal = 1;
				moveVertical = -1;
				break;
			case 2:
				moveHorizontal = 1;
				moveVertical = 0;
				break;
			case 3:
				moveHorizontal = 1;
				moveVertical = 1;
				break;
			case 4:
				moveHorizontal = 0;
				moveVertical = -1;
				break;
			case 5:
				moveHorizontal = 0;
				moveVertical = 1;
				break;
			case 6:
				moveHorizontal = -1;
				moveVertical = -1;
				break;
			case 7:
				moveHorizontal = -1;
				moveVertical = 0;
				break;
			case 8:
				moveHorizontal = -1;
				moveVertical = 1;
				break;
			}
			gameObject.GetComponent<Move> ().moveHorizontal = (float)moveHorizontal;
			gameObject.GetComponent<Move> ().moveVertical = (float)moveVertical;
			frameMovementDuration = random.Next (speedMin, speedMax);
		} else {
			frameMovementDuration--;
		}
	}

}

