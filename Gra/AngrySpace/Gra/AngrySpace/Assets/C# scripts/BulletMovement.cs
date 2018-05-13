using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMovement : MonoBehaviour {
    public int xDirectionCoeffcient;
    public float speed = 500;
    Vector3 shootCurrent;
    float xBound;
    float rotationSpeed = 100.0f; //degrees per second
	bool isRotating = false;
    GameObject planet;

    void Start()
    {
        CalculateScreenBounds.calculate();
        xBound = xDirectionCoeffcient * CalculateScreenBounds.distanceToHorizontalBoundOfView;
        shootCurrent = new Vector3(xDirectionCoeffcient * 0.5f, 0, 0);

    }

	void Update ()
    {
		if(!isRotating)
			transform.Translate(speed * Time.deltaTime * shootCurrent);

		if (!isInWindow ())
			Destroy (gameObject);
		
    }

	bool isInWindow(){
		if (transform.position.x > CalculateScreenBounds.distanceToHorizontalBoundOfView)
			return false;
		if (transform.position.x < CalculateScreenBounds.distanceToHorizontalBoundOfView * (-1))
			return false;
		if (transform.position.y > CalculateScreenBounds.distanceToVerticalBoundOfView)
			return false;
		if (transform.position.y < CalculateScreenBounds.distanceToVerticalBoundOfView * (-1))
			return false;

		return true;	
	}

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Planet")
        {
            planet = col.gameObject;
			Vector3 direction;
			if (transform.position.y > planet.transform.position.y)
			if (xDirectionCoeffcient > 0)
				direction = Vector3.back;
			else
				direction = Vector3.forward;
			else if (xDirectionCoeffcient < 0)
				direction = Vector3.back;
			else
				direction = Vector3.forward;
			
			transform.RotateAround (planet.transform.position, direction, rotationSpeed * Time.deltaTime);

        }
    }

	void OnCollisionExit(){
		isRotating = false;
	}

	void OnCollisionStart(){
		isRotating = true;
	}
}
