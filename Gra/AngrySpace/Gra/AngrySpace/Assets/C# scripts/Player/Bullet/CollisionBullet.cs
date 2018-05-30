using UnityEngine;
using UnityEngine.UI;

public class CollisionBullet : MonoBehaviour {
    public Text textLives;
	public string BulletTag;
    void Start()
    {
    }

    void OnCollisionEnter(Collision col)
    {	
		if (col.gameObject.CompareTag(BulletTag))
        {
            Destroy(col.gameObject);
			int lives = gameObject.GetComponent<PlayerAttributes>().lives;
			lives--;
			gameObject.GetComponent<PlayerAttributes> ().lives = lives;

            textLives.text = lives.ToString();
            if (lives == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
