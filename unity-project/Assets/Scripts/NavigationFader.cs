/*
    FadeObjectInOut.cs
    Hayden Scott-Baron (Dock) - http://starfruitgames.com
    6 Dec 2012 
 
    This allows you to easily fade an object and its children. 
    If an object is already partially faded it will continue from there. 
    If you choose a different speed, it will use the new speed. 
 
    NOTE: Requires materials with a shader that allows transparency through color.  
*/
 
using UnityEngine;
using System.Collections;

public class NavigationFader : MonoBehaviour
{
 
    // publically editable speed

    public float fadeDelay = 0.0f;
    public float fadeTime = 0.5f;
    public bool fadedOutOnStart = false;
    public bool fadeInOnStart = false;
    public bool fadeOutOnStart = false;

    public string fadeState = "in";

    private bool logInitialFadeSequence = false;


    private Material[] opaqueMaterials;
    private Material[] fadeMaterials;
 
 
 
    // store colours
    private Color[] colors;
 
    // allow automatic fading on the start of the scene
    IEnumerator Start()
    {
        fadeState = "in";

        Renderer[] rendererObjects = GetComponentsInChildren<Renderer>(); 

        fadeMaterials = new Material[rendererObjects.Length];
        opaqueMaterials = new Material[rendererObjects.Length];

        for (int i = 0; i < rendererObjects.Length; i++)
        {
            opaqueMaterials [i] = rendererObjects [i].material;
            fadeMaterials [i] = MakeFadeableMaterial(rendererObjects [i].material);
        }

//        yield return null; 
        yield return new WaitForSeconds(0); 

        if (fadedOutOnStart)
        {
            for (int i = 0; i < rendererObjects.Length; i++)
            {
                rendererObjects [i].enabled = false; 
            }

            logInitialFadeSequence = true; 
            float alphaValue = 0; 
            for (int i = 0; i < rendererObjects.Length; i++)
            {
                Color newColor = (colors != null ? colors [i] : rendererObjects [i].material.color);
                newColor.a = Mathf.Min(newColor.a, alphaValue); 
                newColor.a = Mathf.Clamp(newColor.a, 0.0f, 1.0f);              
                rendererObjects [i].material.SetColor("_Color", newColor); 
            }

            fadeState = "out";
        }

        if (fadeInOnStart)
        {
            logInitialFadeSequence = true; 
            FadeIn(); 
        }
 
        if (fadeOutOnStart)
        {
            FadeOut(fadeTime); 
        }

//        Debug.Log("End of Start() and fadeState is " + fadeState);
    }
 
    // check the alpha value of most opaque object
    float MaxAlpha()
    {
        float maxAlpha = 0.0f; 
        Renderer[] rendererObjects = GetComponentsInChildren<Renderer>(); 
        foreach (Renderer item in rendererObjects)
        {
            maxAlpha = Mathf.Max(maxAlpha, item.material.color.a); 
        }
        return maxAlpha; 
    }

 
    // fade sequence
    IEnumerator FadeSequence(float fadingOutTime)
    {
        fadeState = "fading";

        // log fading direction, then precalculate fading speed as a multiplier
        bool fadingOut = (fadingOutTime < 0.0f);
        float fadingOutSpeed = 1.0f / fadingOutTime; 

        // grab all child objects
        Renderer[] rendererObjects = GetComponentsInChildren<Renderer>(); 

        for (int i = 0; i < rendererObjects.Length; i++)
        {
            rendererObjects [i].material = fadeMaterials [i];
        }

        if (colors == null)
        {
            //create a cache of colors if necessary
            colors = new Color[rendererObjects.Length]; 
 
            // store the original colours for all child objects
            for (int i = 0; i < rendererObjects.Length; i++)
            {
                colors [i] = rendererObjects [i].material.color; 
            }
        }
 
        // make all objects visible
        for (int i = 0; i < rendererObjects.Length; i++)
        {
            rendererObjects [i].enabled = true;
        }
 
 
        // get current max alpha
        float alphaValue = MaxAlpha();  
 
 
        // This is a special case for objects that are set to fade in on start. 
        // it will treat them as alpha 0, despite them not being so. 
        if (logInitialFadeSequence && !fadingOut)
        {
            alphaValue = 0.0f; 
            logInitialFadeSequence = false; 
        }
 
        // iterate to change alpha value 
        while ((alphaValue >= 0.0f && fadingOut) || (alphaValue <= 1.0f && !fadingOut))
        {
            alphaValue += Time.deltaTime * fadingOutSpeed; 
 
            for (int i = 0; i < rendererObjects.Length; i++)
            {
                Color newColor = (colors != null ? colors [i] : rendererObjects [i].material.color);
                newColor.a = Mathf.Min(newColor.a, alphaValue); 
                newColor.a = Mathf.Clamp(newColor.a, 0.0f, 1.0f);              
                rendererObjects [i].material.SetColor("_Color", newColor); 
            }
 
            yield return null; 
        }
 
        // turn objects off after fading out
        if (fadingOut)
        {
            for (int i = 0; i < rendererObjects.Length; i++)
            {
                rendererObjects [i].enabled = false; 
            }
        }
 
        for (int i = 0; i < rendererObjects.Length; i++)
        {
            rendererObjects [i].material = opaqueMaterials [i];
        }

        if (fadingOut)
        {
            fadeState = "out";
        }
        else
        {
            fadeState = "in";
        }

         
    }

 
    public void FadeIn()
    {
        FadeIn(fadeTime); 
    }

    public void FadeOut()
    {
        FadeOut(fadeTime);         
    }

    public void FadeIn(float newFadeTime)
    {
//        Debug.Log("FadeIn(" + newFadeTime + ")");
        StopAllCoroutines(); 
        logInitialFadeSequence = true; 

        StartCoroutine("FadeSequence", newFadeTime); 
    }

    public void FadeOut(float newFadeTime)
    {
//        Debug.Log("FadeOut(" + newFadeTime + ")");
        StopAllCoroutines(); 
        StartCoroutine("FadeSequence", -newFadeTime); 
    }

    Material MakeFadeableMaterial(Material from)
    {
        Material m = new Material(from);
        m.SetFloat("_Mode", 2);
        m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        m.SetInt("_ZWrite", 0);
        m.DisableKeyword("_ALPHATEST_ON");
        m.EnableKeyword("_ALPHABLEND_ON");
        m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        m.renderQueue = 3000;
        return m;
    }
}