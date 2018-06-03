using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusLife : MonoBehaviour {
    public Transform canvasBonusLife;
    public bool startBonus = false;
    public float timeLeft;
    private bool countDownTime = false;
    // Use this for initialization
    void Start () {
        canvasBonusLife.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (startBonus)
        {
            canvasBonusLife.gameObject.SetActive(true);
            countDownTime = true;
            startBonus = false;
            timeLeft = GetComponent<PlayerAttributes>().superSpeedTime;
        }
        if (countDownTime)
        {
            if ((timeLeft -= Time.deltaTime) < 0)
            {
                countDownTime = false;
                canvasBonusLife.gameObject.SetActive(false);
            }

        }

	}
}
