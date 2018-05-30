using UnityEngine;
using System.Collections;

public class ClickButtons : MonoBehaviour
{

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

