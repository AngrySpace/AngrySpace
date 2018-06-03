using UnityEngine;
/// <summary>
/// Instantiate bullet.
/// </summary>
public class InstantiateBullet : MonoBehaviour
{
  
	/// <summary>
	/// The bullet.
	/// </summary>
	public GameObject bullet;
	/// <summary>
	/// The bullet tag.
	/// </summary>
	public string BulletTag;
    /// <summary>
    /// Curret bullet rate.
    /// </summary>
    private float currentRate;
	/// <summary>
	/// set the player's default rate of fire 
	/// </summary>
	void Start ()
	{
		currentRate = gameObject.GetComponent<PlayerAttributes> ().rateOfFire;
	}
	/// <summary>
	/// update if the player can shot 
	/// </summary>
	void Update ()
	{
		bool isFire = gameObject.GetComponent<PlayerAttributes> ().isFire;
		if ((currentRate -= Time.deltaTime) < 0f && isFire == true) {
			GameObject bulletCopy = (GameObject)Instantiate (bullet, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation);
			currentRate = gameObject.GetComponent<PlayerAttributes> ().rateOfFire;
			bulletCopy.tag = BulletTag;
			gameObject.GetComponent<PlayerAttributes> ().isFire = false;
		}
	}
}
