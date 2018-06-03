using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for controlling bonuses.
/// </summary>
public class BonusesController : MonoBehaviour
{
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
    /// <summary>
    /// Planet lifes. When equals to zero, the planet will be destroyed and 
    /// with some probability there should appear bonus in planet's place.
    /// </summary>
    public int planetLifes;
}
