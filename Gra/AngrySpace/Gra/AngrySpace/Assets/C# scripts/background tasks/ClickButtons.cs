using UnityEngine;

/// <summary>
/// Clas responsible for reacting to clicking buttons.
/// </summary>
public class ClickButtons : MonoBehaviour
{
    /// <summary>
    /// Sets players' isFire field to true if users click on buttons responsible for shooting.
    /// </summary>
    void Update ()
	{
		if(Input.GetButtonDown("Fire1") && GameObject.Find("Player1")){
			GameObject.Find("Player1").GetComponent<PlayerAttributes>().isFire = true;
		}
		if (Input.GetButtonDown("Fire12") && GameObject.Find("Player2"))
		{
			GameObject.Find("Player2").GetComponent<PlayerAttributes>().isFire = true;
		}			
	}
}

