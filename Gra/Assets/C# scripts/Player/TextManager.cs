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
	
	void Start ()
	{
		UpdateTextLives ();
	}

	/// <summary>
	/// Updates the text lives.
	/// </summary>
	public void UpdateTextLives ()
	{
		textLives.text = gameObject.GetComponent<PlayerAttributes> ().lives.ToString ();
	}
}

