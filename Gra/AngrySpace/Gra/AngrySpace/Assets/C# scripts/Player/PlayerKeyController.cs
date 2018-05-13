using UnityEngine;
using System.Collections;

public class PlayerKeyController : MonoBehaviour
{
	public string VerticalKey;
	public string HorizontalKey;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.GetComponent<Move>().moveVertical = Input.GetAxis(VerticalKey);
		gameObject.GetComponent<Move>().moveHorizontal = Input.GetAxis(HorizontalKey);
	}
}

