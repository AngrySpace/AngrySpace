using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour
{
	public int lives;
	public bool isFire;
	public float rateOfFire;
	public float speed;
    public bool isSuperSpeed = false;
    public float superSpeedTime;
    private float typicalRateOfFire;
	// Use this for initialization
	void Start ()
	{
        typicalRateOfFire = rateOfFire;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (isSuperSpeed)
        {
            if (GetComponent<AIEnemy>())
            {
                if (GetComponent<AIEnemy>().enabled == true)
                    rateOfFire = 0.2f;
            }
            else
                rateOfFire = 0;
            if ((superSpeedTime -= Time.deltaTime) < 0)
            {
                rateOfFire = typicalRateOfFire;
                superSpeedTime = 5;
                isSuperSpeed = false;
            }

        }
	}
}

