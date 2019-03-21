﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationControls : MonoBehaviour
{

    private Vector2 targetCoordinates;
    private Vector2 deviceCoordinates;
    private LocationService service;
    private bool ready = false;
    private bool enableByRequest = true;
    private float idealDistanceFromTarget = 0.0001f;
    private float proximity;
    private float dLatitude, dLongitude;

    public float tLatitude = 34.19291f, tLongitude = -118.56092f;
    public int maxWait = 10;
   
    public Text text;
    public Text distance;
    public Text detected;
    public Text internalCompass;
    public Text NS;
    public Text WE;
    public Text NSAbsoluteValue;
    public Text WEAbsoluteValue;

    private string NSdirection;
    private string WEdirection;
    private string totalDirection;
    private float trueHeading;

    public GameObject button;
    public Animator buttonAnimator;

    public GameObject directionIndicator;
    public Animator indicatorAnimator;

    void Start()
    {
        buttonAnimator = GetComponent<Animator>();
        targetCoordinates = new Vector2(tLatitude, tLongitude);
        StartCoroutine(GetLocation());
      
    }

    IEnumerator GetLocation()
    {
        service = Input.location;
        if (!enableByRequest && !service.isEnabledByUser)
        {
            Debug.Log("Location Services not enabled by user");
            yield break;
        }
        Input.compass.enabled = true;
        service.Start();

        while (service.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {  Debug.Log("Timed out");
            yield break;
        }
        if (service.status == LocationServiceStatus.Failed)
        {
            text.text = "Unable to determine device location";
            yield break;
        }
       
            //text.text = "Target Location : " + tLatitude + ", " + tLongitude + "\nMy Location: " + service.lastData.latitude + ", " + service.lastData.longitude;
           //dLatitude = service.lastData.latitude;
            //dLongitude = service.lastData.longitude;
        Debug.Log("Location service loaded");
        ready = true;
        //startCalculate();
        yield break;
    }


    void Update()
    {

        if (ready == true)
        {
            StartCoroutine(UpdateGPS());
        }


    }
    IEnumerator UpdateGPS()
    {
        float seconds = .5f; //Every 2 seconds

        while (true) { 
            text.text = "Target Location : " + tLatitude + ", " + tLongitude + "\nMy Location: " + Input.location.lastData.latitude + ", " + Input.location.lastData.longitude;
            dLatitude = Input.location.lastData.latitude;
            dLongitude = Input.location.lastData.longitude;
            trueHeading = Input.compass.trueHeading;

            StartCalculate();

            yield return new WaitForSeconds(seconds);
        }      

      
    }

    public void StartCalculate()
    {
        deviceCoordinates = new Vector2(dLatitude, dLongitude);
        proximity = Vector2.Distance(targetCoordinates, deviceCoordinates);
        if (proximity <= idealDistanceFromTarget)
        {
           
           //destroy hint object? and set trigger permanent during session, so you can use a back button
           //How to keep variables persistent between scenes and yield break when we are finished.
            distance.text = "Distance : " + proximity.ToString();
            detected.text = "Target Detected";
            buttonAnimator.SetTrigger("LocationFound");
            NS.text = "";
            WE.text = "";
            internalCompass.text = "";

        }
        else
        {
            distance.text = "Out of Range Distance : " + proximity.ToString(); 
            //If phone faces the target, attached or animate in a gameobject
           internalCompass.text = "\ntrueHeading: " + Input.compass.trueHeading;
            totalDirection = "";
            if  (tLatitude < dLatitude && (Mathf.Abs(tLatitude - dLatitude)) > .0001f)
            {
                NS.text = "target is South";
                NSdirection = "S";
                float S = Mathf.Abs(tLatitude - dLatitude);
                NSAbsoluteValue.text = "absoluteValue = " + S.ToString();
            }

            else if( tLatitude > dLatitude && (Mathf.Abs(tLatitude - dLatitude)) > .0001f)
            {
                NS.text = "target is North";
                NSdirection ="N";
                float n = Mathf.Abs(tLatitude - dLatitude);
                NSAbsoluteValue.text = "absoluteValue = " + n.ToString();
            }
            else {
                NS.text = "";
                NSdirection = "";
            }

            if (tLongitude < dLongitude && (Mathf.Abs(tLongitude - dLongitude)) > .0001f)
            {
                WE.text = "target is West";
                WEdirection = "W";
                float W = Mathf.Abs(tLongitude - dLongitude);
                WEAbsoluteValue.text = "absoluteValue = " + W.ToString();
            }

            else if (tLongitude > dLongitude && (Mathf.Abs(tLongitude - dLongitude)) > .0001f)
            {
                WE.text = "target is East";
                WEdirection = "E";
                float E = Mathf.Abs(tLongitude - dLongitude);
                WEAbsoluteValue.text = "absoluteValue = " + E.ToString();
            }
            else
            {
                WE.text = "";
                WEdirection = "";
            }
            totalDirection = NSdirection + WEdirection;
            detected.text = "";
            if (totalDirection == "NE" && 0.0f < trueHeading && trueHeading <= 90.0f ) {
                detected.text = "Direction Detected NE - Pointing towards target";
            }
            if (totalDirection == "SE" && 90.0f < trueHeading && trueHeading <= 180.0f)
            {
                detected.text = "Direction Detecte SE - Pointing towards target";
            }
            if (totalDirection == "SW" && 180.0f < trueHeading && trueHeading <= 270.0f)
            {
                detected.text = "Direction Detected SW - Pointing towards target";
            }
            if (totalDirection == "NW" && 270.0f < trueHeading && trueHeading <= 360.0f)
            {
                detected.text = "Direction Detected NW - Pointing towards target";
            }
            if (totalDirection == "N" && 315.0f < trueHeading || trueHeading <= 45.0f)
            {
                detected.text = "Direction Detected N - Pointing towards target";
            }
            if (totalDirection == "S" && 135.0f < trueHeading && trueHeading <= 225.0f)
            {
                detected.text = "Direction Detected S - Pointing towards target";
            }
            if (totalDirection == "E" && 45.0f < trueHeading && trueHeading <= 135.0f)
            {
                detected.text = "Direction Detected E - Pointing towards target";
            }
            if (totalDirection == "W" && 225.0f < trueHeading && trueHeading <= 315.0f)
            {
                detected.text = "Direction Detected W - Pointing towards target";
            }




        }
    }
}