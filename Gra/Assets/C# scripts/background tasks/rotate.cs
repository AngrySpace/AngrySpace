using UnityEngine;

/// <summary>
/// Class responsible of rotation.
/// </summary>
public class rotate : MonoBehaviour {

    /// <summary>
    /// Angle of rotation.
    /// </summary>
    public float angle = 1;

    /// <summary>
    /// Rotates object every frame by the given angle.
    /// </summary>
    void Update ()
    {
        transform.Rotate(new Vector3(1,1,1) * Time.deltaTime, angle: this.angle);
	}
}
