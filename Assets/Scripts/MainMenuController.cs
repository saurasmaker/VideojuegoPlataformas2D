using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        if (sceneName.Equals("Exit"))
        {
            Application.Quit();
            return;
        }

        SceneManager.LoadScene(sceneName);

        return;
    }
    
}
