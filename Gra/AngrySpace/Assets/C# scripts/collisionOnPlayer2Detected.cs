using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionOnPlayer2Detected : MonoBehaviour {

    public static int lifes;
    public Text textLifes;

    void Start()
    {
        lifes = 5;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "BulletPlayer1")
        {
            Destroy(col.gameObject);
            lifes--;
            textLifes.text = lifes.ToString();
            if (lifes == 0)
            {
                moveEnemy.dead = true;
                Destroy(gameObject);
            }
        }
    }
}
