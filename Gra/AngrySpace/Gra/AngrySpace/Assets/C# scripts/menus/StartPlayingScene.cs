using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartPlayingScene : MonoBehaviour
{
    public static string playerName;

    public void StartLevel(int level)
    {
        playerName = EventSystem.current.currentSelectedGameObject.name;
        Time.timeScale = 1;
        Application.LoadLevel(level);
    }
}