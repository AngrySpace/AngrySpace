using UnityEngine;
using System.Collections;

public class ClickButtons : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
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

