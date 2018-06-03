using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Player's text manu manager
/// </summary>
public class TextManager : MonoBehaviour
{
	/// <summary>
	/// Player lives text
	/// </summary>
	public Text textLives;

    public Text textBonusTimeLeft;
	
	void Start ()
	{
		UpdateTextLives ();
	}

    void Update()
    {
        if (gameObject.GetComponent<PlayerAttributes>().isSuperSpeed)
            UpdateBonusTimeLeft();
    }
	/// <summary>
	/// Updates the text lives.
	/// </summary>
	public void UpdateTextLives ()
	{
		textLives.text = gameObject.GetComponent<PlayerAttributes> ().lives.ToString ();
	}

    private void UpdateBonusTimeLeft()
    {
        textBonusTimeLeft.text = gameObject.GetComponent<PlayerBonusLife>().timeLeft.ToString("N2");
    }
}

