﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Add this as a component on a button to get touch controls
public class TouchSceneControls : MonoBehaviour
{
    public void LoadNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartChapter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
