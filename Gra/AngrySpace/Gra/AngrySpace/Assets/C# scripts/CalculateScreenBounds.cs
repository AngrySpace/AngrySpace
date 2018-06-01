using UnityEngine;

/// <summary>
/// Class responsible for calculating screen bounds, depending on resolution etc.
/// </summary>
public class CalculateScreenBounds : MonoBehaviour {

    /// <summary>
    /// Distance to vertical bound of view from the centre of camera direct.
    /// </summary>
    public static float distanceToVerticalBoundOfView;
    /// <summary>
    /// Distance to horizontal bound of view from the centre of camera direct.
    /// </summary>
    public static float distanceToHorizontalBoundOfView;

    /// <summary>
    /// Method to calculate disances to vertical and horizontal bounds of view, depending on screen resolution.
    /// </summary>
    public static void calculate()
    {
        float fieldOfView = Camera.main.fieldOfView;
        float radius = Camera.main.transform.position.z;
        radius = -radius; //because "z" coordinate of main camera is negative
        float tanFieldOfView = Mathf.Tan(30 * Mathf.Deg2Rad);
        distanceToVerticalBoundOfView = tanFieldOfView * radius;
        distanceToHorizontalBoundOfView = distanceToVerticalBoundOfView * Screen.width / Screen.height;
    }	
}
