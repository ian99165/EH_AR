using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Input = UnityEngine.Input;
using UnityEngine.VFX;

public class DissolvingControllerTut : MonoBehaviour
{
    public SkinnedMeshRenderer SkinnedMesh;
    public VisualEffect VFXGraph;
    public float dissolveRate = 0.125f;
    public float refreshRate = 0.025f;
    private Material[] skinnedMaterials;
    void Start()
    {
        if (SkinnedMesh != null)
            skinnedMaterials = SkinnedMesh.materials;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveCo());
        }
    }

    IEnumerator DissolveCo()
    {
        if (VFXGraph != null)
        {
            VFXGraph.Play();
            //VFXGraph.enabled=false;
        }
        if (skinnedMaterials.Length > 0)
        {
            float counter = 0;
            while(skinnedMaterials[0].GetFloat("_DissolveAmount")<1)
            {
                counter += dissolveRate;
                for (int i = 0; i < skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
} 
