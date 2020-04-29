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
        SceneManager.LoadScene("Puzzle", LoadSceneMode.Single);

    }

    public void OpenScene3()
    {
        SceneManager.LoadScene("Scene 4", LoadSceneMode.Single);

    }

    public void OpenScene4()
    {
        SceneManager.LoadScene("Scene 4", LoadSceneMode.Single);

    }



}