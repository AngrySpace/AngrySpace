using UnityEngine;

/// <summary>
/// Class to control planet lifes and show explosion effect after it dies.
/// </summary>
public class PlanetLifesController : MonoBehaviour
{
    /// <summary>
    /// The number of planet lifes.
    /// </summary>
    private int lifes;
    /// <summary>
    /// GameObject representing the explossion efect.
    /// </summary>
    public GameObject explosionEffect;
    /// <summary>
    /// GameObject to instantiate when starting explosion.
    /// </summary>
    private GameObject explosionObject;
    /// <summary>
    /// Boolean field saying if explosion has started.
    /// </summary>
    private bool isExploding = false;
    /// <summary>
    /// Time of explosion to be shown before destroying the planet and explosion.
    /// </summary>
    private float explosionTime = 0.4f;
    /// <summary>
    /// Bonus to create in the place of exploded planet.
    /// </summary>
    private GameObject bonusToCreate;
    private static System.Random  random = new System.Random();
    /// <summary>
    /// The main camera.
    /// </summary>
    private GameObject mainCamera;

    /// <summary>
    /// Initialization method. Sets main camera object and planet lifes.
    /// </summary>
    public void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        lifes = mainCamera.GetComponent<BonusesController>().planetLifes;
    }

    /// <summary>
    /// Checks if planet is dead and exploding and when explosion is over, with some probability the
    /// bonus will be generated.
    /// </summary>
    void Update()
    {
        if (isExploding)
            explosionTime -= Time.deltaTime;
        if (explosionTime <= 0)
        {        
            int bonusRate = mainCamera.GetComponent<BonusesController>().bonusRate;
            int randomIsBonus = random.Next(0, bonusRate);
            if (randomIsBonus == 0)
            {
                generateBonus();               
            }
            destroyObjects();          
        }
    }

    /// <summary>
    /// Randomly finds and generates bonus object.
    /// </summary>
    private void generateBonus()
    {
        int randomBonus = random.Next(0, mainCamera.GetComponent<BonusesController>().bonusesNumber);
        bonusToCreate = mainCamera.GetComponent<BonusesController>().bonuses[randomBonus];
        Instantiate(bonusToCreate, transform.position, transform.rotation);
    }

    /// <summary>
    /// Cleans game. Destroyes all unused objects, such as planet or explosion object.
    /// </summary>
    private void destroyObjects()
    {
        Destroy(explosionObject);
        Destroy(GetComponent<AsteroidAttributes>().colliderSprite);
        mainCamera.GetComponent<AsteroidGenerator>().addedAsteroidList.Remove(gameObject);
        Destroy(gameObject);
    }

    /// <summary>
    /// Checks if planet collides with bullets.
    /// </summary>
    public void OnCollisionEnter(Collision col)
    {
        GameObject bullet = col.gameObject;
        if (bullet.tag == "PlayerBullet" || bullet.tag == "EnemyBullet")
        {
            decrementLifes();
        }
    }

    /// <summary>
    /// Decrements planet's lifes and creates explosion object if planet is destroyed.
    /// </summary>
    private void decrementLifes()
    {
        if (--lifes == 0)
        {
            explosionObject = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            isExploding = true;
        }
    }
}
