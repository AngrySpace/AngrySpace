using UnityEngine;
using System.Collections;
/// <summary>
/// Player key controller, after pushing the button, update position of the player
/// </summary>
public class PlayerKeyController : MonoBehaviour
{
	/// <summary>
	/// The vertical key.
	/// </summary>
	public string VerticalKey;
	/// <summary>
	/// The horizontal key.
	/// </summary>
	public string HorizontalKey;

	/// <summary>
	/// Update this position of the player.
	/// </summary>
	void Update ()
	{
		gameObject.GetComponent<Move> ().moveVertical = Input.GetAxis (VerticalKey);
		gameObject.GetComponent<Move> ().moveHorizontal = Input.GetAxis (HorizontalKey);
	}
}

