using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public Button Chapter2Button, Chapter3Button, Chapter4Button;
    int levelPassed;
    public Animator transitionAnim;
    private LocationService service;

    void Start()
    {
        service = Input.location;
         if (!service.isEnabledByUser)
        {
            Debug.Log("Location Services not enabled by user");
          
        }
       service.Start();


        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Chapter2Button.interactable = false;
        Chapter3Button.interactable = false;
        Chapter4Button.interactable = false;

        switch (levelPassed)
        {
            case 1:
                Chapter2Button.interactable = true;
                break;
            case 2:
                Chapter2Button.interactable = true;
                Chapter3Button.interactable = true;
                break;
            case 3:
                Chapter2Button.interactable = true;
                Chapter3Button.interactable = true;
                Chapter4Button.interactable = true;
                break;
            case 4:
                Chapter2Button.interactable = true;
                Chapter3Button.interactable = true;
                Chapter4Button.interactable = true;
                break;
        }
    }
    public void LevelToLoad(string sceneName)
    {
    
        StartCoroutine(LoadScene(sceneName));

    }


    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        service.Stop();
        SceneManager.LoadScene(sceneName);
    }

        public void ResetPlayerPrefs()
    {
        Chapter2Button.interactable = false;
        Chapter3Button.interactable = false;
        Chapter4Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }

    public void ResetLevelTwo()
    {
        Chapter2Button.interactable = true;
        Chapter3Button.interactable = false;
        Chapter4Button.interactable = false;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 1);
    }

    public void ResetLevelThree()
    {
        Chapter2Button.interactable = true;
        Chapter3Button.interactable = true;
        Chapter4Button.interactable = false;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 2);
    }

    public void ResetLevelFour()
    {
        Chapter2Button.interactable = true;
        Chapter3Button.interactable = true;
        Chapter4Button.interactable = true;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelPassed", 3);
    }
}
