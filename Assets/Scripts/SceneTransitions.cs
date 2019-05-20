using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitions : MonoBehaviour {
    public Animator transitionAnim;
    public string sceneName;


    // Update is called once per frame
    void Update(){
       
    }



    public void ButtonPressWrapper () {


        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene(){

        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonPressWrapperWithPara(string sceneNameButton)
    {


        StartCoroutine(LoadScene2(sceneNameButton));

    }



    IEnumerator LoadScene2(string sceneNameButton)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneNameButton);
    }
}
