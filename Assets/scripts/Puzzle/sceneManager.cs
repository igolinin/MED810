using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{


    public void OpenScene1()
    {

        SceneManager.LoadScene("PuzzleTelescope1", LoadSceneMode.Single);
    }

    public void OpenScene2()
    {
        SceneManager.LoadScene("PuzzleTelescope2", LoadSceneMode.Single);

    }

    public void OpenScene3()
    {
        SceneManager.LoadScene("PuzzleTelescope3", LoadSceneMode.Single);

    }

    public void MainMenu()
    {
        
        SceneManager.LoadScene("TelescopeMainMenu", LoadSceneMode.Single);

    }

}