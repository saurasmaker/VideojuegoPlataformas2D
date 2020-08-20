using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    bool paused;
    Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            canvas.enabled = paused;
            Time.timeScale = (paused) ? 0 : 1;
        }

    }

    public void Resume()
    {
        canvas.enabled = paused = false;   
        Time.timeScale = 1;

        return;
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);

        return;
    }

}
