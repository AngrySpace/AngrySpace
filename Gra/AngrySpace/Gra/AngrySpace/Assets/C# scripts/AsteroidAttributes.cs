using UnityEngine;
using System.Collections;

public class AsteroidAttributes : MonoBehaviour
{
	public int mass;
	public int radius;
	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<SphereCollider> ().radius = radius;
		gameObject.GetComponent<Rigidbody> ().mass = mass;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

