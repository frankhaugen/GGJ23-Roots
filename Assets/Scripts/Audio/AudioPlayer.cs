using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource Source;

    public bool Fade;

    public void Play()
    {
        if (Source == null) return;
        Source.Play();
    }
    
    void Start()
    {
        if (Source == null)
        {
            return;
        }

        if (Fade)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            Source.Play();
        }
    }

    public void End()
    {
        if (Source == null)
        {
            return;
        }
        if (Fade)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            Source.Stop();
        }
    }

    private void OnDestroy()
    {
        if (Source == null || !enabled)
        {
            return;
        }

        try
        {
            StartCoroutine(FadeOut());
        }
        catch
        {
            // ignored
        }
    }

    IEnumerator FadeIn()
    {
        Source.volume = 0;
        var speed = 0.01f;
        Source.Play();

        for (float i = 0; i < 1; i += speed)
        {
            Source.volume = i;
            yield return new WaitForSeconds(0.2f);
        }

        Source.loop = true;
        Source.Play();
    }

    IEnumerator FadeOut()
    {
        Source.volume = 1;
        var speed = 0.01f;
        Source.Stop();
        StopCoroutine(FadeIn());
        for (float i = 1; i > 0; i -= speed)
        {
            Source.volume = i;
            yield return new WaitForSeconds(0.2f);
        }

        Source.Stop();
    }
}