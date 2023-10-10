using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaterialContoller : MonoBehaviour
{
    [SerializeField]Renderer _renderer;
    [SerializeField] Material matOriginal;
    [SerializeField] Material matDissolve;
    [SerializeField] Material matPhase;
    [SerializeField] float fadeTime = 2.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnSpawn(InputValue value)
    {
        StartCoroutine(DoPahse());
    }
    void OnDie(InputValue value)
    {
        StartCoroutine(DoDissolve());
    }

    IEnumerator DoPahse()
    {
        matPhase.SetFloat("_SplitValue",0f);
        _renderer.material = matPhase;
        for(;;)
        {
            if(_renderer.material.GetFloat("_SplitValue") >= 2.2f) break;
            Debug.Log("up");
            _renderer.material.SetFloat("_SplitValue",_renderer.material.GetFloat("_SplitValue") + 0.01f);
            yield return null;
        }
        _renderer.material = matOriginal;
       
    }
    IEnumerator DoDissolve()
    {
        matPhase.SetFloat("_SplitValue",1.1f);
        _renderer.material = matDissolve;
        for(;;)
        {
            if(_renderer.material.GetFloat("_SplitValue") < 0) break;
            Debug.Log("up");
            _renderer.material.SetFloat("_SplitValue",_renderer.material.GetFloat("_SplitValue") - 0.005f);
            yield return null;
        }
        
    }
}
