using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentFader : MonoBehaviour {

    public float fadeSpeed, fadeOpacity;
    private float origOpacity;

    Material mat;
    public bool willFade;
    private void Start() {
        mat = GetComponent<MeshRenderer>().material;
        origOpacity = mat.color.a;
    }
    private void Update() {
        if (willFade) {
            FadeStart();
        }
        else {
            ResetFade();
        }
    }

    //fade material into transparent
    void FadeStart() {
        Color currentColor = mat.color;
        Color TransitionColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeOpacity, fadeSpeed * Time.deltaTime));
        mat.color = TransitionColor;
    }

    //reset material to opaque
    void ResetFade() {
            Color currentColor = mat.color;
            Color TransitionColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, origOpacity, fadeSpeed * Time.deltaTime));
            mat.color = TransitionColor;
        }
    }

//Script by Jacob