﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public GameObject mapControlButton;
    public Text buttonText;
    public Transform onScreenMap;
    public Transform offScreenMap;
    public float speed;
    private bool offScreen;
    public Animator mapAnim;
    public Button goButton;

    // Start is called before the first frame update
    void Start()
    {
        offScreen = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (offScreen == false)
        {

               

            transform.position = Vector2.MoveTowards(transform.position, onScreenMap.position, speed * Time.deltaTime);
           
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, offScreenMap.position, speed * Time.deltaTime);
        }
    }
    public void MapControl ()
    {
        if (offScreen == true)
        {
            mapAnim.SetTrigger("FadeIN");
            offScreen = false;
            goButton.interactable = false;
            buttonText.text = "Hide Map";
        }
        else
        {
            mapAnim.SetTrigger("FadeOUT");
            offScreen = true;
            goButton.interactable = true;
            buttonText.text = "Map";
        }
    }
}
