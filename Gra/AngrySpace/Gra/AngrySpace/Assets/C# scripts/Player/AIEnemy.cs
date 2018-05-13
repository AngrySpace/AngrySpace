using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour
{
	public int chanceToShoot;
	private System.Random random;
	private int Directions = 8;
	private int moveHorizontal, moveVertical;
	private int frameMovementDuration = 0;
	// Use this for initialization
	void Start ()
	{
		random = new System.Random();
		gameObject.GetComponent<PlayerKeyController> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		RandomShoot ();
		RandomMovement ();
	}

	void RandomShoot(){
		bool randomShot = random.Next (0, chanceToShoot) == 0 ? true : false;
		gameObject.GetComponent<PlayerAttributes> ().isFire = randomShot;
	}

	void RandomMovement()
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
			frameMovementDuration = random.Next (10, 30);
		} else {
			frameMovementDuration--;
		}
	}

}

