using UnityEngine;

public class InstantiateBullet : MonoBehaviour {
   
    public GameObject bullet;
	public string BulletTag;
	private float currentRate;
	void Start()
	{
		currentRate = gameObject.GetComponent<PlayerAttributes>().rateOfFire;;	
	}

    void Update ()
    {
		bool isFire = gameObject.GetComponent<PlayerAttributes> ().isFire;
		if ((currentRate -= Time.deltaTime) < 0f && isFire == true) {
			GameObject bulletCopy = (GameObject)Instantiate(bullet, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
			currentRate = gameObject.GetComponent<PlayerAttributes>().rateOfFire;; 
			bulletCopy.tag = BulletTag;
			gameObject.GetComponent<PlayerAttributes> ().isFire = false;
		}
    }
}
