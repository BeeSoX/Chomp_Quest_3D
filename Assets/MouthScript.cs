using UnityEngine;
using System.Collections;

public class MouthScript : MonoBehaviour
{
    [Range(0, 8)]
    public float mouthPause = 0f; // Temps entre les cycles d'animation
    public bool cannotMouth = false; // Permet de désactiver l'animation
    private SkinnedMeshRenderer characterMeshRenderer;
    private float mouthWeight = 0f;
    public float mouthSpeed = 50f; // Vitesse plus faible pour plus de fluidité
    private float maxMouthWeight = 100f;
    private float minMouthWeight = 0f;
    private bool opening = true; // Indique si la bouche s'ouvre ou se ferme

    void Start()
    {
        characterMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        StartCoroutine(MouthAnimation());
    }

    void Update()
    {
        if (cannotMouth) return; // Arrête l'animation si cannotMouth est activé

        if (opening)
        {
            mouthWeight = Mathf.MoveTowards(mouthWeight, maxMouthWeight, mouthSpeed * Time.deltaTime);
        }
        else
        {
            mouthWeight = Mathf.MoveTowards(mouthWeight, minMouthWeight, mouthSpeed * Time.deltaTime);
        }

        characterMeshRenderer.SetBlendShapeWeight(1, mouthWeight); // BlendShape index 1 (ajuste si besoin)
    }

    IEnumerator MouthAnimation()
    {
        while (!cannotMouth)
        {
            yield return new WaitForSeconds(mouthPause);
            opening = true; // Commence à ouvrir

            yield return new WaitForSeconds(1f);
            opening = false; // Ferme la bouche
        }
    }
}
