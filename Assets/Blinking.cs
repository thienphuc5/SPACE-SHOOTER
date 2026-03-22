using UnityEngine;
using System.Collections;

public class Blinking : MonoBehaviour
{
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.2f); // tốc độ nhấp nháy
        }
    }
}
