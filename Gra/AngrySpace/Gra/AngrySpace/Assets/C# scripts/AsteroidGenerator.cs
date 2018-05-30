using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Asteroid generator.
/// </summary>
public class AsteroidGenerator : MonoBehaviour
{
	/// <summary>
	/// The number of asteroids.
	/// </summary>
	public int NumberOfAsteroids;
	/// <summary>
	/// The asteroid list.
	/// </summary>
	public List<GameObject> AsteroidList;
	private List<GameObject> addedAsteroidList = new List<GameObject> ();
	/// <summary>
	/// The minimum mass.
	/// </summary>
	public int MinMass;
	/// <summary>
	/// The max mass.
	/// </summary>
	public int MaxMass;
	/// <summary>
	/// The minimum radius.
	/// </summary>
	public int MinRadius;
	/// <summary>
	/// The max radius.
	/// </summary>
	public int MaxRadius;
	/// <summary>
	/// The collider sprite.
	/// </summary>
	public GameObject colliderSprite;
	Quaternion rotation = new Quaternion ();
	private System.Random random;

	void Start ()
	{
		random = new System.Random ();
		rotation.x = 0;
		rotation.y = 0;
		rotation.z = 0;
		GenerateAsteroids ();
	}

	void GenerateAsteroids ()
	{
		Time.timeScale = 1;
		Vector3 position = findPosition ();
		int radius = random.Next (MinRadius, MaxRadius);
		GameObject asteroid = buildAsteroid (position, radius);
		addedAsteroidList.Add (asteroid);
		colliderSprite.transform.localScale = new Vector3 (radius / 2.7f, radius / 2.7f, radius / 2.7f);
		asteroid.GetComponent<AsteroidAttributes> ().colliderSprite = (GameObject)Instantiate (colliderSprite, asteroid.transform.position, asteroid.transform.rotation);
		for (int i = 1; i < NumberOfAsteroids; i++) {
			float maxTime = 5;
			do {
				position = findPosition ();
				radius = random.Next (MinRadius, MaxRadius);
				maxTime -= Time.deltaTime;
			} while (isInsideOtherAsteroid (i, position, radius) || maxTime < 0);
			asteroid = buildAsteroid (position, radius);
			addedAsteroidList.Add (asteroid);
			colliderSprite.transform.localScale = new Vector3 (radius / 2.7f, radius / 2.7f, radius / 2.7f);
			asteroid.GetComponent<AsteroidAttributes> ().colliderSprite = (GameObject)Instantiate (colliderSprite, asteroid.transform.position, asteroid.transform.rotation);
		}
	}
	/// <summary>
	/// Builds the asteroid, update with parameters
	/// </summary>
	/// <returns>The asteroid.</returns>
	/// <param name="position">Position.</param>
	/// <param name="radius">Radius.</param>
	private GameObject buildAsteroid (Vector3 position, int radius)
	{
		int rand = random.Next (0, AsteroidList.Count);
		GameObject asteroid = (GameObject)Instantiate (AsteroidList [rand], position, rotation);
		asteroid.AddComponent<AsteroidAttributes> ();
		asteroid.GetComponent<AsteroidAttributes> ().mass = random.Next (MinMass, MaxMass);
		asteroid.GetComponent<AsteroidAttributes> ().radius = radius;
		return asteroid;
	}

	private Vector3 findPosition ()
	{
		Vector3 position = new Vector3 ();
		CalculateScreenBounds.calculate ();
		int distanceToVerticalBound = (int)CalculateScreenBounds.distanceToVerticalBoundOfView - 1;
		int distanceToHorizontalBound = (int)CalculateScreenBounds.distanceToHorizontalBoundOfView - 1;
		position.y = random.Next ((-1) * distanceToVerticalBound, distanceToVerticalBound);
		position.x = random.Next ((-1) * distanceToHorizontalBound, distanceToHorizontalBound);
		return position;
	}

	private bool isInsideOtherAsteroid (int currentIndex, Vector3 position, int radius)
	{

		for (int j = 0; j < currentIndex; ++j) {
			float currentPlanetDistance = Mathf.Sqrt (Mathf.Pow (position.x - addedAsteroidList [j].transform.position.x, 2) + Mathf.Pow (position.y - addedAsteroidList [j].transform.position.y, 2));
			float minimalExpectedDistance = radius + addedAsteroidList [j].GetComponent<AsteroidAttributes> ().radius;
			if (currentPlanetDistance < minimalExpectedDistance)
				return true;    
		}
		return false;
	}
}

