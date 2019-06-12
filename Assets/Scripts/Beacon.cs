using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Beacon : MonoBehaviour
{

    private Vector2 targetCoordinates;
    private Vector2 deviceCoordinates;
    private LocationService service;
    private bool ready = false;
    private bool enableByRequest = true;
    private float idealDistanceFromTarget = 0.0001f;
    private float proximity;
    private float dLatitude, dLongitude;

    //public float tLatitude = 34.020019f, tLongitude = -118.380901f;
    public float tLatitude = 34.1922454f, tLongitude = -118.381479f;
    public int maxWait = 10;


   // public GameObject beacon;
    public Animator beaconAnimator;

 

    void Start()
    {
        //beaconAnimator = GetComponent<Animator>();
        targetCoordinates = new Vector2(tLatitude, tLongitude);


        StartCoroutine(GetLocation());

    }

    IEnumerator GetLocation()
    {
        //This doesn't work in Android if you don't have it already enabled before getting to the screen
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
        {
            Debug.Log("Timed out");
            yield break;
        }
        if (service.status == LocationServiceStatus.Failed)
        {
           
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

        while (true)
        {
            dLatitude = Input.location.lastData.latitude;
            dLongitude = Input.location.lastData.longitude;
       
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

             beaconAnimator.SetTrigger("Start");


        }
        else
        {
            if (beaconAnimator.GetCurrentAnimatorStateInfo(0).IsName("Start"))
            {
                beaconAnimator.SetTrigger("Stop");
            }
        }
    }
}