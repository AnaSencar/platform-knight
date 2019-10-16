using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderSystem : MonoBehaviour
{
    [SerializeField] private float timeToFadeOut;
    [SerializeField] private float timeToFadeIn;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator FadeOut()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / timeToFadeOut;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / timeToFadeIn;
            yield return null;
        }
    }

}
