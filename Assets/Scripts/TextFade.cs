using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    [SerializeField] Text text;
    void Start()
    {
        Invoke("FadeOut", 3f);
    }
    void FadeOut()
    {
        text.CrossFadeAlpha(0f, 0.5f, false);
    }
}
