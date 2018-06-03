using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible for placing score bars.
/// </summary>
public class PlaceScoreBars : MonoBehaviour {
    /// <summary>
    /// First player's score bar.
    /// </summary>
    public Image player1Score;
    /// <summary>
    /// Second player's score bar.
    /// </summary>
    public Image player2Score;
    /// <summary>
    /// First player's bonus fast shots time left bar.
    /// </summary>
    public Image player1Bonus;
    /// <summary>
    /// Second player's bonus fast shots time left bar.
    /// </summary>
    public Image player2Bonus;

    /// <summary>
    /// Counts screen bounds and places score bars in upper corners.
    /// </summary>
    void Start ()
    {
        Vector3 scoreBarSize = player1Score.rectTransform.sizeDelta;
        float screenSizeX = Screen.width / 2.0f;
        float negativeScreenSizeX = -screenSizeX;
        float screenSizeY = Screen.height / 2.0f;
        player1Score.rectTransform.Translate(negativeScreenSizeX + scoreBarSize.x / 2, screenSizeY - scoreBarSize.y / 2, -10);
        player2Score.rectTransform.Translate(screenSizeX - scoreBarSize.x / 2, screenSizeY - scoreBarSize.y / 2, -10);
        Vector3 bonusBarSize = player1Bonus.rectTransform.sizeDelta;
        player1Bonus.transform.Translate(negativeScreenSizeX + scoreBarSize.x + bonusBarSize.x / 2, screenSizeY - bonusBarSize.y / 2, -10);
        player2Bonus.transform.Translate(screenSizeX - scoreBarSize.x - bonusBarSize.x / 2, screenSizeY - bonusBarSize.y / 2, -10);
    }
}
