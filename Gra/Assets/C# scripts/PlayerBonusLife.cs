using UnityEngine;

/// <summary>
/// Class responsible for controlling bonus fast shots time and showing canvas when the bonus is active.
/// </summary>
public class PlayerBonusLife : MonoBehaviour {
    /// <summary>
	/// Canvas with bonus fast shots remaining time.
	/// </summary>
    public Transform canvasBonusFastShots;
    /// <summary>
	/// Field to store info if the bonus has been just started.
	/// </summary>
    public bool isBonusStarted = false;
    /// <summary>
	/// Time left for player to have the bonus.
	/// </summary>
    public float timeLeft;
    /// <summary>
	/// Field letting to check if the bonus lifetime should be counted down.
	/// </summary>
    private bool shouldCountDownTime = false;

    /// <summary>
    /// Sets canvas active to false initially.
    /// </summary>
    void Start () {
        canvasBonusFastShots.gameObject.SetActive(false);
	}

    /// <summary>
    /// Checks every frame if should start counting down bonus lifetime and if so, does that and displays 
    /// canvas with the left time.
    /// </summary>
    void Update () {
		if (isBonusStarted)
        {
            bonusStart();
        }
        if (shouldCountDownTime)
        {
            countDownTime();
        }
	}

    /// <summary>
    /// Start counting down bonus lifetime. Enables canvas which shows left time.
    /// </summary>
    private void bonusStart()
    {
        canvasBonusFastShots.gameObject.SetActive(true);
        shouldCountDownTime = true;
        isBonusStarted = false;
        timeLeft = GetComponent<PlayerAttributes>().superSpeedTime;
    }

    /// <summary>
    /// Counts down bus lifetime. If less then zero, disables canvas which shows left time.
    /// </summary>
    private void countDownTime()
    {
        if ((timeLeft -= Time.deltaTime) < 0)
        {
            shouldCountDownTime = false;
            canvasBonusFastShots.gameObject.SetActive(false);
        }
    }
}
