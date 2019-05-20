using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Add this as a component on a button to get touch controls


public class InstructionCardControls : MonoBehaviour
{



    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
