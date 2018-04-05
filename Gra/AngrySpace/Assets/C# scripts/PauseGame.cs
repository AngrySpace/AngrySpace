using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public Transform mainCamera;
	
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
	}

    public void Pause()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        mainCamera.GetComponent<InstantiateBullet>().enabled = false;
        mainCamera.GetComponent<InstantiateBulletEnemy>().enabled = false;
    }

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        mainCamera.GetComponent<InstantiateBullet>().enabled = true;
        mainCamera.GetComponent<InstantiateBulletEnemy>().enabled = true;
    }
}

