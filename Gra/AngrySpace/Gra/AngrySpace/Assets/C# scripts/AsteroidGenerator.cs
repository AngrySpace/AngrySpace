using UnityEngine;
using System.Collections.Generic;

public class AsteroidGenerator : MonoBehaviour
{
	public int NumberOfAsteroids;
	public List<GameObject> AsteroidList;
	public int MinMass;
	public int MaxMass;
	public int MinRadius;
	public int MaxRadius;
	private System.Random random;

	// Use this for initialization
	void Start ()
	{
		random = new System.Random();
		GenerateAsteroids ();
	}

	void GenerateAsteroids(){
		CalculateScreenBounds.calculate ();
		int distanceToVerticalBound = (int) CalculateScreenBounds.distanceToVerticalBoundOfView -1;
		int distanceToHorizontalBound = (int) CalculateScreenBounds.distanceToHorizontalBoundOfView -1;
		Quaternion rotation = new Quaternion();
		rotation.x = 0;
		rotation.y = 0;
		rotation.z = 0;
		GameObject asteroid;
		for (int i = 0; i < NumberOfAsteroids; i++) {
			int rand = random.Next (1, AsteroidList.Count);
			Vector3 position = new Vector3();
			position.y = random.Next ((-1) * distanceToVerticalBound, distanceToVerticalBound);
			position.x = random.Next ((-1) * distanceToHorizontalBound, distanceToHorizontalBound);
			asteroid = (GameObject) Instantiate(AsteroidList[rand], position, rotation);  
			asteroid.AddComponent<AsteroidAttributes> ();
			asteroid.GetComponent<AsteroidAttributes>().mass = random.Next(MinMass, MaxMass);
			asteroid.GetComponent<AsteroidAttributes> ().radius = random.Next (MinRadius, MaxRadius);
		}
	}

}

