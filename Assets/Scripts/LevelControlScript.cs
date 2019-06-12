using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LevelControl
{
    public class LevelControlScript : MonoBehaviour
    {

        public static LevelControlScript instance = null;
        int sceneIndex, levelPassed;
        string sceneName;

  
        void Start()
        {

            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
               
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneName = SceneManager.GetActiveScene().name;
            levelPassed = PlayerPrefs.GetInt("LevelPassed");

        }

        public void CVMatch()
        {

            Debug.Log("CVMATCH");
            //if (sceneIndex == 3)
            if (sceneName == "CameraSceneCVMatch1")
            {  //CameraScene1
               
                PlayerPrefs.SetInt("LevelPassed", 1);
            }
            else if (sceneName == "CameraSceneGeoLocation")
            {  //CameraScene2
                Debug.Log("Passing Level 2");
                PlayerPrefs.SetInt("LevelPassed", 2);
            }
            else if (sceneName == "CameraSceneCVMatch3a" || sceneName == "CameraSceneCVMatch3b" )
            {  //CameraScene3
                PlayerPrefs.SetInt("LevelPassed", 3);
            }
            else if (sceneName == "CameraSceneCVMatch4")
            {  //CameraScene4
                PlayerPrefs.SetInt("LevelPassed", 4);
            }
        }



        public void resetPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}