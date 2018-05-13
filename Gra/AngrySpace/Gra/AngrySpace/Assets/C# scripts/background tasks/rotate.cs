using UnityEngine;

public class rotate : MonoBehaviour {

    public float angle = 1;

	void Update ()
    {
        transform.Rotate(new Vector3(1,1,1) * Time.deltaTime, angle: this.angle);
	}
}
