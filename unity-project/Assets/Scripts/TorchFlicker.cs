using UnityEngine;
using System.Collections;

public class TorchFlicker : MonoBehaviour
{

    public float baseLightIntensity = 0.5f;

    private float px = 0;
    private float py = 0;


    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        float perlin = Mathf.PerlinNoise(px, py);
//        float random = Random.Range(0f, 1f);
        GetComponent<Light>().intensity = perlin + baseLightIntensity;
//        GetComponent<Light>().intensity = random + 0.25f;
        px += 0.1f;
        py += 0.1f;

    }
}
