using UnityEngine;
/// <summary>
/// Collision player with bullet manager
/// </summary>
public class CollisionBullet : MonoBehaviour
{
	/// <summary>
	/// The bullet tag.
	/// </summary>
	public string BulletTag;

	/// <summary>
	/// On collision with bullet decrement number of player's lives
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter (Collision col)
	{	
		if (col.gameObject.CompareTag (BulletTag)) {
			Destroy (col.gameObject);
			gameObject.GetComponent<PlayerAttributes> ().DecrementLives ();
		}
	}
}
