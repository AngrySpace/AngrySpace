using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBulletEnemy : MonoBehaviour {

    public GameObject bullet;
    GameObject bulletCopy;
    public Transform enemyHand;
    public int chanceToShoot = 100;
    private System.Random randomShoot;
    public static bool isPlayer2Playing = false;
	
	void Update () {

        if (isPlayer2Playing)
        {
            InstantiatePlayer2Bullet();
        }
        else
        {
            InstantiateEnemyBullet();
        }
        
    }
    void InstantiatePlayer2Bullet()
    {
        if (Input.GetButtonDown("Fire12"))
        {
            bulletCopy = (GameObject)Instantiate(bullet, enemyHand.position, enemyHand.rotation);
            bulletCopy.name = "BulletPlayer2";
        }
    }

    void InstantiateEnemyBullet()
    {
        if (moveEnemy.dead)
        {
            return;
        }

        randomShoot = new System.Random();
        int shouldShoot = randomShoot.Next(0, chanceToShoot);
        if (shouldShoot == 0)
        {
            bulletCopy = (GameObject)Instantiate(bullet, enemyHand.position, enemyHand.rotation);
            bulletCopy.name = "BulletPlayer2";

        }
    }
}
