using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Player's text manu manager
/// </summary>
public class TextManager : MonoBehaviour
{
	/// <summary>
	/// Player lives text.
	/// </summary>
	public Text textLives;
    /// <summary>
	/// Remaining bonus fast shots time text
	/// </summary>
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

    /// <summary>
	/// Updates the bons fast shots left time text.
	/// </summary>
    private void UpdateBonusTimeLeft()
    {
        textBonusTimeLeft.text = gameObject.GetComponent<PlayerBonusLife>().timeLeft.ToString("N2");
    }
}

