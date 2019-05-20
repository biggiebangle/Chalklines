using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioEnd : MonoBehaviour
{
    public GameObject soundControlButton;
    private bool paused;
    public Animator transitionAnim;

    //Audioclip time resets to zero after completion.
    private const int V = 0;

    private bool timeStarted;
    public Text buttonText;

    public string nextSceneName;
    public AudioSource audioName;


    // Start is called before the first frame update
    void Start()
    {
        paused = true;
        buttonText.text = "Play";
        timeStarted = false;
}

    // Update is called once per frame
    void Update()
    {
 
        StartCoroutine(ChangeSceneAtEndofAudio());

    }

    public void SoundControl ()
    {

        if(paused == true)
        {
            audioName.Play();
            paused = false;
            buttonText.text = "Pause";


        }
        else
        {
            audioName.Pause();
            paused = true;
            buttonText.text = "Play";

        }
    }
    //private IEnumerator waitAudio(int sceneIndex)
    private IEnumerator ChangeSceneAtEndofAudio()
    {
        //yield return new WaitForSeconds(nameClip.clip.length);
        yield return new WaitForSeconds(5);
        //print(nameClip.time);
        if (System.Math.Abs(audioName.time) > V)
        {
            timeStarted = true;
        }
        //nameClip.time == nameClip.clip.length
        if (timeStarted == true && System.Math.Abs(audioName.time) == V)
        {

            //Fadeout scene - aka trigger animation? or should animation just be at beginning? and stop audio

            print("end audio");
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(nextSceneName);

        }






    }

}
