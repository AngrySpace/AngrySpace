using UnityEngine;

/// <summary>
/// Class representing asteroid attributes.
/// </summary>
public class AsteroidAttributes : MonoBehaviour
{
    /// <summary>
    /// Mass of the asteroid.
    /// </summary>
    public int mass;
    /// <summary>
    /// Radius of the asteroid collider.
    /// </summary>
    public int radius;
    /// <summary>
    /// The collider sprite.
    /// </summary>
    public GameObject colliderSprite;

    /// <summary>
    /// Sets radius and mass to the asteroid components.
    /// </summary>
    void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = radius;
        gameObject.GetComponent<Rigidbody>().mass = mass;
    }
}
