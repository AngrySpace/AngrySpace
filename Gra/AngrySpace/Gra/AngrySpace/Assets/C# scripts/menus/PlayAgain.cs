using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {
    public Transform canvas;

    public void StartLevel(int level)
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
}
