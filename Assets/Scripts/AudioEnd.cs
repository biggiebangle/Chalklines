using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioEnd : MonoBehaviour
{
    public GameObject soundControlButton;
    private bool paused;

    //Audioclip time resets to zero after completion.
    private const int V = 0;

    private bool timeStarted;
    public Text buttonText;

    public int nextSceneIndex;
    public AudioSource nameClip;


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
 
        StartCoroutine(changeSceneAtEndofAudio());

    }

    public void SoundControl ()
    {

        if(paused == true)
        {
            nameClip.Play();
            paused = false;
            buttonText.text = "Pause";


        }
        else
        {
            nameClip.Pause();
            paused = true;
            buttonText.text = "Play";

        }
    }
    //private IEnumerator waitAudio(int sceneIndex)
    private IEnumerator changeSceneAtEndofAudio()
    {
        //yield return new WaitForSeconds(nameClip.clip.length);
        yield return new WaitForSeconds(5);
        //print(nameClip.time);
        if (System.Math.Abs(nameClip.time) > V)
        {
            timeStarted = true;
        }
        //nameClip.time == nameClip.clip.length
        if (timeStarted == true && System.Math.Abs(nameClip.time) == V)
        {

            //Fadeout scene - aka trigger animation? or should animation just be at beginning? and stop audio
            print("at the end");
            SceneManager.LoadScene(nextSceneIndex);

        }






    }

}
