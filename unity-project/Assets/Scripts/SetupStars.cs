using UnityEngine;
using System.Collections;

public class SetupStars : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        GetComponent<ParticleSystem>().randomSeed = 1;
        GetComponent<ParticleSystem>().Simulate(0, true, true);
        Debug.Log("Set particle system random seed.");
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }
}
