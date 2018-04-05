using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionOnPlanet : MonoBehaviour {

    Vector3 gravityVec;
    bool isColisionDetected = false;
    Vector3 colliderPosition;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "BulletPlayer1" || col.gameObject.name == "BulletPlayer2")
        {
            col.gameObject.transform.parent = gameObject.transform;
            Destroy(col.gameObject);

            /*  change vec of bullet trajection */
            //colliderPosition = col.gameObject.transform.position;
            //isColisionDetected = true;
            //// Destroy(col.gameObject);
            //Vector3 planetPosition = this.gameObject.transform.position;
            //gravityVec = new Vector3(planetPosition.x - colliderPosition.x, planetPosition.y - colliderPosition.y, planetPosition.z - colliderPosition.z);
            //Vector3 newVec = new Vector3(shootPlayer1.shootCurrent.y * gravityVec.z - shootPlayer1.shootCurrent.z * gravityVec.y, shootPlayer1.shootCurrent.z * gravityVec.x - shootPlayer1.shootCurrent.x * gravityVec.z, shootPlayer1.shootCurrent.x * gravityVec.y - shootPlayer1.shootCurrent.y * gravityVec.x);
            //newVec += colliderPosition;
            //shootPlayer1.shootCurrent = newVec;
            //Debug.Log("collision!");
        }
    }
}
