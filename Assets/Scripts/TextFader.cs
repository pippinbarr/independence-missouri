using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TextFader : MonoBehaviour
{

    public float fadeDelay = 0.0f;
    public float fadeTime = 0.5f;
    public bool fadedOutOnStart = false;
    public bool fadeInOnStart = false;
    public float minDisplayTime = 1.0f;
    public string nextScene = "Game";

    private bool waitingForInput = false;


    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine("FadeStart");
    }

    IEnumerator FadeStart()
    {
        Text t = GetComponent<Text>();
        t.CrossFadeAlpha(0f, 0, false);  

        if (fadeDelay != 0)
        {
            yield return new WaitForSeconds(fadeDelay);
        }

        t.CrossFadeAlpha(1f, fadeTime, false);  
        fadeInOnStart = false;

        yield return new WaitForSeconds(fadeTime);

        yield return new WaitForSeconds(minDisplayTime);

        waitingForInput = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (waitingForInput)
        {
            if (Input.anyKey || Input.GetButton("Fire1"))
            {
                StartCoroutine("FadeInGame");
                waitingForInput = false;
            }
        }
    }

    IEnumerator FadeInGame()
    {
        Text t = GetComponent<Text>();

        t.CrossFadeAlpha(0f, fadeTime, false);

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(nextScene);
    }
}
