using UnityEngine;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public Transform mainCamera;
	
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

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
    }

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

