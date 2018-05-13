using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour {

    public void StartLevel(int level)
    {
        Time.timeScale = 1;
        Application.LoadLevel(level);
    }
}
