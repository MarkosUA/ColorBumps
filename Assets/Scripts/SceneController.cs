using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController 
{
    private static string _gameSceneIndex = "GameScene";
    private static string _startMenuScene = "StartMenuScene";

    public static void LoadGameScene()
    {
        SceneManager.LoadScene(_gameSceneIndex);
    }

    public static void LoadStartScene()
    {
        SceneManager.LoadScene(_startMenuScene);
    }    
}
