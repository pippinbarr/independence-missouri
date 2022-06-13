using UnityEngine;
using System.Collections;

public class ContemplationHandler : MonoBehaviour
{
    public LightCycle lightCycle;
    public Light contemplationLight;
    public Light contemplationLightDestination;

    private GameObject currentLocation = null;
    private float startTime = 0.0f;
    private bool currentLocationContemplated = false;

    private float C_LIGHT_MAX = 8.0f;
    private float contemplationLightSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {
        startTime = 0;
    }
	
    // Update is called once per frame
    void Update()
    {
//        Debug.Log(lightCycle.time);

        if (currentLocationContemplated)
            return;

        GameObject constellation = GameObject.Find(currentLocation.name + " Constellation");

        if (constellation)
        {
            GameObject lines = constellation.transform.Find("Lines").gameObject;

            if (lines.GetComponent<Renderer>().enabled)
            {
                Vector3 pos = currentLocation.transform.position;
                contemplationLight.transform.position = new Vector3(pos.x, pos.y, pos.z);
                contemplationLight.intensity = C_LIGHT_MAX;
                contemplationLight.enabled = true;
                currentLocationContemplated = true;
            }
            else if (lightCycle.time - startTime >= 1 && lightCycle.time - Mathf.Floor(lightCycle.time) >= 0.5)
            {
                Debug.Log("Contemplated " + currentLocation.name + "!");
                lines.GetComponent<NavigationFader>().FadeIn();
//                    lines.GetComponent<Renderer>().enabled = true;
                currentLocationContemplated = true;
//                    Debug.Log("Starting coroutine...");
                ShowContemplationLight(currentLocation, false);
            }
        }
    }

    IEnumerator StartContemplationLight(Light light)
    {
        light.intensity = 0;
        light.enabled = true;

        while (light.intensity < C_LIGHT_MAX)
        {
            light.intensity += contemplationLightSpeed;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void ShowContemplationLight(GameObject o, bool destination)
    {
        GameObject constellation = GameObject.Find(o.name + " Constellation");
        if (constellation)
        {
            GameObject lines = constellation.transform.Find("Lines").gameObject;
            if (lines.GetComponent<Renderer>().enabled)
            {
                var pos = o.transform.position;
                if (destination)
                {
                    contemplationLightDestination.transform.position = new Vector3(pos.x, pos.y, pos.z);
                    contemplationLightDestination.intensity = C_LIGHT_MAX;
                    contemplationLightDestination.enabled = true;
                }
                else
                {
                    contemplationLight.transform.position = new Vector3(pos.x, pos.y, pos.z);
                    contemplationLight.intensity = 0;
                    contemplationLight.enabled = true;
                    StartCoroutine(StartContemplationLight(contemplationLight));
                }
            }
        }
    }

    public void ChangedLocation(GameObject to)
    {
        currentLocation = to;
        startTime = lightCycle.time;
        currentLocationContemplated = false;
    }
}
