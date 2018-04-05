using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {
    public Transform canvas;
    public Transform mainCamera;
    public GameObject player1;
    public GameObject player2;

    public void playAgain()
    {
        Debug.Log("Again");
        canvas.gameObject.SetActive(false);
        moveEnemy.dead = false;
        Time.timeScale = 1;
       
        mainCamera.GetComponent<InstantiateBullet>().enabled = true;
        mainCamera.GetComponent<InstantiateBulletEnemy>().enabled = true;
    }

    public void StartLevel(int level)
    {
        Debug.Log("Again");
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        SceneManager.LoadScene(level);
    }
}
