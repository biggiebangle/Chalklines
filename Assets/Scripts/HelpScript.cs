using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpScript : MonoBehaviour
{


    int levelPassed;
    public Animator transitionAnim;


    void Start()
    {
       

        levelPassed = PlayerPrefs.GetInt("LevelPassed");
         
    }
    public void SceneToLoad(string sceneName)
    {
    
        StartCoroutine(LoadScene(sceneName));

    }


    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
       yield return new WaitForSeconds(1.5f); 
        SceneManager.LoadScene(sceneName);
    }

        public void ResetPlayerPrefs()
    {

        PlayerPrefs.DeleteAll();
    }

    public void ResetLevelTwo()
    {
         
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 1);
    }

    public void ResetLevelThree()
    {
         
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 2);
    }

    public void ResetLevelFour()
    {
         
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 3);
    }
}
