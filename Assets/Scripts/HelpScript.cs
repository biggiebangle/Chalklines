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
        SceneToLoad("MainMenu");
    }

    public void LevelOneAvailable()
    {

        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 1);
        SceneToLoad("MainMenu");

    }

    public void LevelTwoAvailable()
    {
         
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 2);
        SceneToLoad("MainMenu");

    }

    public void LevelThreeAvailable()
    {
         
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 3);
        SceneToLoad("MainMenu");
    }

    public void LevelFourAvailable()
    {
         
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 4);
        SceneToLoad("MainMenu");
    }
}
