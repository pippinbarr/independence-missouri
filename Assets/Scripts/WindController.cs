using UnityEngine;
using System.Collections;

public class WindController : MonoBehaviour
{

    //    public AudioClip softWind;
    //    public AudioClip strongWind;
    public float gustiness = 0.2f;
    private float xScale = 5f;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0f, 1f) < gustiness)
        {
            GetComponent<AudioSource>().pitch = 0.75f + Mathf.PerlinNoise(Time.time / xScale, 0.0f);
        }

    }
}
