using UnityEngine;
using System.Collections;

public class AsteroidAttributes : MonoBehaviour
{
    public int mass;
    public int radius;
    public GameObject colliderSprite;

    void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = radius;
        gameObject.GetComponent<Rigidbody>().mass = mass;
    }
}
