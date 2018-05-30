using UnityEngine;
using System.Collections;
/// <summary>
/// Player attributes, like speed, rate of fire, ...
/// </summary>
public class PlayerAttributes : MonoBehaviour
{
	/// <summary>
	/// The lives.
	/// </summary>
	public int lives;
	/// <summary>
	/// The is fire.
	/// </summary>
	public bool isFire;
	/// <summary>
	/// The rate of fire.
	/// </summary>
	public float rateOfFire;
	/// <summary>
	/// The speed.
	/// </summary>
	public float speed;
	/// <summary>
	/// The is super speed.
	/// </summary>
	public bool isSuperSpeed = false;
	/// <summary>
	/// The super speed time.
	/// </summary>
	public float superSpeedTime;
	private float typicalRateOfFire;
	// Use this for initialization
	void Start ()
	{
		typicalRateOfFire = rateOfFire;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isSuperSpeed) {
			if (GetComponent<AIEnemy> ()) {
				if (GetComponent<AIEnemy> ().enabled == true)
					rateOfFire = 0.2f;
			} else
				rateOfFire = 0;
			if ((superSpeedTime -= Time.deltaTime) < 0) {
				rateOfFire = typicalRateOfFire;
				superSpeedTime = 5;
				isSuperSpeed = false;
			}

		}
	}
	/// <summary>
	/// Decrements the lives and update the text manager
	/// </summary>
	public void DecrementLives(){
		lives--;
		gameObject.GetComponent<TextManager> ().UpdateTextLives ();
		if (lives == 0)
		{
			Destroy(gameObject);
		}
	}
	/// <summary>
	/// Increments the lives and update the text manager
	/// </summary>
	public void IncrementLives(){
		lives++;
		gameObject.GetComponent<TextManager> ().UpdateTextLives ();
	}
}

