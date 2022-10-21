using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]     //Run this script last

public class MenuUIHandler : MonoBehaviour
{
    public void StartNewGame()                  //Move between scenes when start button is pressed
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()                          //Save and exit when exit button is pressed
    {
        DataManager.instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
