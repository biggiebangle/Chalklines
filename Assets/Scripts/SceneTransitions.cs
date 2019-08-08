using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitions : MonoBehaviour {
    public Animator transitionAnim;
    public string sceneName;
    [SerializeField]
    public string alternateSceneName;
    public int level;
    int levelPassed;


    private void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }
    void Update(){
       
    }



    public void ButtonPressWrapper () {


        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene(){

        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonPressWrapperWithPara(string sceneNameButton)
    {


        StartCoroutine(LoadScene2(sceneNameButton));

    }



    IEnumerator LoadScene2(string sceneNameButton)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneNameButton);
    }

    public void InstructionsScene()
    {


       //StartCoroutine(LoadScene3());

   // }

   // IEnumerator LoadScene3()
    //{
       //transitionAnim.SetTrigger("end");
        //yield return new WaitForSeconds(.2f);
        if (levelPassed >= level)
        {
            //Load audio async??
           //LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(alternateSceneName));
            SceneManager.LoadScene(alternateSceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
