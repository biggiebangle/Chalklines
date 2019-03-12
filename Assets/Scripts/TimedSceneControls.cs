using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneControls : MonoBehaviour
{

    public float delayBeforeLoading = 10f;
    //This is added as a field when added a game component within the scene

    public string sceneNameToLoad;

    private float timeElapsed;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
