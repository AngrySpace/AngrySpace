using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for controlling bonuses.
/// </summary>
public class BonusesController : MonoBehaviour
{
    /// <summary>
    /// Asteroid lifes. When equal to zero, asteroid is destroyed.
    /// </summary>
    public int planetLifes;
    /// <summary>
    /// Chance that there will be created bonus in asteroid's place.
    /// </summary>
    public int bonusRate;
    /// <summary>
    /// Number of possible bonuses kinds.
    /// </summary>
    public int bonusesNumber;
    /// <summary>
    /// List of possible bonuses kinds.
    /// </summary>
    public List<GameObject> bonuses;
}
