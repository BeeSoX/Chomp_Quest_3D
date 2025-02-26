using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingScript : MonoBehaviour
{
    [Range (1,8)]
    public float blinkPause;

    public bool cannotBlink;

    GameObject character;
    SkinnedMeshRenderer characterMeshRenderer;
    float blinkWeight;
    public float blinkSpeed = 1500f;
    float maxBlinkWeight = 100f;
    float minBlinkWeight = 0f;
    public bool isBlinking;
    
    void Start()
    {
        character = this.gameObject;
        characterMeshRenderer = character.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();
        StartCoroutine("Blink");

    }

    void Update()
    {
        if (!cannotBlink) {
        if (isBlinking) {

        if (blinkWeight <= maxBlinkWeight) {
            blinkWeight += Time.deltaTime * blinkSpeed;
            characterMeshRenderer.SetBlendShapeWeight(0, blinkWeight);
        }
        } else {

        if (minBlinkWeight <= blinkWeight) {
            blinkWeight -= Time.deltaTime * blinkSpeed;
            characterMeshRenderer.SetBlendShapeWeight(0, blinkWeight);
        }
        }
        }
    }

    [ContextMenu("Test Closed")]
    public void TestClosed()
    {
        characterMeshRenderer.SetBlendShapeWeight(0, 100);
    }

    
    [ContextMenu("Test Open")]
    public void TestOpened()
    {
        characterMeshRenderer.SetBlendShapeWeight(0, 0);
    }

    IEnumerator Blink() {
        while (!cannotBlink) {
yield return new WaitForSeconds(blinkPause);

        isBlinking = true;

        yield return new WaitForSeconds(.2f);

        isBlinking = false;

        yield return null;
        }
    
    }
}
