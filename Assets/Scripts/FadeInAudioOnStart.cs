using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInAudioOnStart : MonoBehaviour
{

    public NavigationHandler input;

    // Use this for initialization
    void Start()
    {
        input.inputEnabled = false;

        Image i = GetComponent<Image>();

        i.CrossFadeAlpha(1, 0, false);

        StartCoroutine("FadeInAudio");
        StartCoroutine("FadeInImage");
    }

    IEnumerator FadeInAudio()
    {
        AudioListener.volume = 0f;

        while (AudioListener.volume < 1f)
        {
            AudioListener.volume += 0.005f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeInImage()
    {
        Image i = GetComponent<Image>();

        yield return new WaitForSeconds(2f);

        input.inputEnabled = true;

        i.CrossFadeAlpha(0, 5, false);
    }


    // Update is called once per frame
    void Update()
    {
	
    }
}
