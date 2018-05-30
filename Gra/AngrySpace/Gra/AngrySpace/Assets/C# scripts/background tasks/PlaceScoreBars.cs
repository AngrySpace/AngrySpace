using UnityEngine;
using UnityEngine.UI;

public class PlaceScoreBars : MonoBehaviour {
    public Image player1Score;
    public Image player2Score;

	void Start ()
    {
        CalculateScreenBounds.calculate();
        Vector3 scoreBarSize = player1Score.rectTransform.sizeDelta;
        float screenSizeX = Screen.width / 2.0f;
        float negativeScreenSizeX = -screenSizeX;
        float screenSizeY = Screen.height / 2.0f;
        player1Score.rectTransform.Translate(negativeScreenSizeX + scoreBarSize.x/2, screenSizeY - scoreBarSize.y/2, -10);
        player2Score.rectTransform.Translate(screenSizeX - scoreBarSize.x / 2, screenSizeY - scoreBarSize.y / 2, -10);
	}
}
