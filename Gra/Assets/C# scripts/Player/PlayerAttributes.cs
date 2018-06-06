using UnityEngine;
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
    /// <summary>
	/// The super speed left time.
	/// </summary>
	public float superSpeedLeftTime;
    /// <summary>
    /// The typical speed time.
    /// </summary>
    private float typicalRateOfFire;
    /// <summary>
    /// The tag of the enemy.
    /// </summary>
    private const string enemyTag = "Enemy";
    /// <summary>
    /// How far from the edge of the screen will be player placed.
    /// </summary>
    private const int moveAwayDistance = 3;
    /// <summary>
    /// The rate of fire that the player will get in super speed mode.
    /// </summary>
    private const float superSpeedPlayerRateOfFire = 0;
    /// <summary>
    /// The rate of fire that the AI enemy will get in super speed mode.
    /// </summary>
    private const float superSpeedAIEnemyRateOfFire = 0.2f;

    /// <summary>
	/// Sets starting values.
	/// </summary>
	void Start ()
	{
        superSpeedLeftTime = superSpeedTime;
		typicalRateOfFire = rateOfFire;
        setPlayerPosition();     
    }

    /// <summary>
	/// Sets player starting position (near screen width ends).
	/// </summary>
    private void setPlayerPosition()
    {
        CalculateScreenBounds.calculate();
        Vector3 playerSize = gameObject.transform.localScale;
        Vector3 positionToSet = new Vector3(CalculateScreenBounds.distanceToHorizontalBoundOfView - playerSize.x - moveAwayDistance, 0, 0);

        if (gameObject.CompareTag(enemyTag))
            gameObject.transform.SetPositionAndRotation(positionToSet, transform.rotation);
        else
            gameObject.transform.SetPositionAndRotation(-positionToSet, transform.rotation);
    }

    /// <summary>
	///Chcecks if super speed bonus is activated - if so, rate of fire will be smaller.
	/// </summary>
    void Update ()
	{
        if (isSuperSpeed) {
            changeRateOfFire();
		}
	}

    /// <summary>
	/// Makes rate of fire smaller - equal to 0, if real player is playing ad equal to 0.2, if it is AIEnemy.
    /// After some time, all should go back to normal.
	/// </summary>
    private void changeRateOfFire()
    {
        if (GetComponent<AIEnemy>() && GetComponent<AIEnemy>().enabled == true)
        {
            rateOfFire = superSpeedAIEnemyRateOfFire;
        }
        else
        {
            rateOfFire = superSpeedPlayerRateOfFire;
        }
        if ((superSpeedLeftTime -= Time.deltaTime) < 0)
        {
            rateOfFire = typicalRateOfFire;
            superSpeedLeftTime = superSpeedTime;
            isSuperSpeed = false;
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

