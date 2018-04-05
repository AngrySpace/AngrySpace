using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour {
   
    public GameObject bullet;
    GameObject bulletCopy;
    public Transform playerHand;

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            bulletCopy = (GameObject)Instantiate(bullet, playerHand.position, playerHand.rotation);
            bulletCopy.name = "BulletPlayer1";
        }

    }
}
