using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLifesController : MonoBehaviour
{

    public int lifes = 1;
    public GameObject explosionEffect;
    private GameObject explosionObject;
    private bool isExploding = false;
    private float explosionTime = 0.4f;
    private GameObject bonusToCreate;
    private static System.Random  random = new System.Random();
    private int randomIsBonus = 1;
    int randomBonus = 1;
    private GameObject mainCamera;

    public void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (isExploding)
            explosionTime -= Time.deltaTime;
        if (explosionTime <= 0)
        {
            isExploding = false;
            explosionTime = 0;
            Destroy(explosionObject);
            int bonusRate = mainCamera.GetComponent<GenerateBonuses>().bonusRate;
            randomIsBonus = random.Next(0, bonusRate);
            if (randomIsBonus == 0)
            {
                randomBonus = random.Next(0, mainCamera.GetComponent<GenerateBonuses>().bonusesNumber);
                bonusToCreate = mainCamera.GetComponent<GenerateBonuses>().bonuses[randomBonus];
                Instantiate(bonusToCreate, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        GameObject bullet = col.gameObject;
        if (bullet.tag == "PlayerBullet" || bullet.tag == "EnemyBullet")
        {
            decrementLifes();
        }
    }

    public void decrementLifes()
    {
        if (--lifes == 0)
        {
            explosionObject = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            isExploding = true;
        }
    }
}
