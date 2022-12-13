using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Pulsing : MonoBehaviour
{
    float targetSize;

    public float smoothSpeed = 0.25f;
    public float maxScale = 1.5f;
    public float minScale = 0.5f;

    private float targetScale;

    void Start()
    {
        targetScale = minScale;
    }

    void Update()
    {
        transform.localScale = UnityEngine.Vector3.Lerp(transform.localScale, targetScale * UnityEngine.Vector3.one, smoothSpeed);
        if(Mathf.Abs(transform.localScale.x - targetScale) < 0.01f)
        {
            targetScale = (targetScale == minScale) ? maxScale : minScale;
        }
    }
}
