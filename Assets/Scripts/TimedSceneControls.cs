using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneControls : MonoBehaviour
{
    private int levelPassed, sceneIndex;
    public float delayBeforeLoading = 10f;
    //This is added as a field when added a game component within the scene

   //public string sceneNameToLoad;

    private float timeElapsed;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is " + scene.name + " " + sceneIndex);
        Debug.Log("Level Passed is " + levelPassed + ".");

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {


        if (sceneIndex == 1) {
            if (levelPassed >= 1)
            {
               //GoStraightToAudio
               SceneManager.LoadScene(sceneIndex + 3);
            }
            else
            {
                SceneManager.LoadScene(sceneIndex + 1);
            }
    
                
            }
            else if (sceneIndex == 6)
            {  

                if (levelPassed >= 2)
                {
                    //GoStraightToAudio
                    SceneManager.LoadScene(sceneIndex + 3);
                }
                else
                {
                    SceneManager.LoadScene(sceneIndex + 1);
                }

            }
            else if (sceneIndex == 11)
            {
                if (levelPassed >= 3)
                {
                    //GoStraightToAudio
                    SceneManager.LoadScene(sceneIndex + 3);
                }
                else
                {
                    SceneManager.LoadScene(sceneIndex + 1);
                }
            }
            else if (sceneIndex == 16)
            {
                if (levelPassed >= 4)
                {
                    //GoStraightToAudio
                    SceneManager.LoadScene(sceneIndex + 3);
                }
                else
                {
                    SceneManager.LoadScene(sceneIndex + 1);
                }
            }
            else
            {
                SceneManager.LoadScene(sceneIndex + 1);
            }

           
        }
    }
}
