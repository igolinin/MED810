using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
public void telescopeSelected()
    {

        Debug.Log("Telescope selected");
        SceneManager.LoadScene("Puzzle", LoadSceneMode.Single);
    }
}
