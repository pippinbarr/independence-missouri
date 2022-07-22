using UnityEngine;
using System.Collections;

public class LightCycle : MonoBehaviour
{
    // How many degrees the moon moves per second
    public float moonSpeed = 25f;
    // Time since start of the game in days (as defined by the moon)
    public float time = 0;
    // The current day in game time
    public float day = 0;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(moonSpeed * Time.deltaTime, 0, 0);
        time += (moonSpeed * Time.deltaTime) / 360;
        day = Mathf.Floor(time);
    }
}
