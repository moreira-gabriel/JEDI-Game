using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float timeToAutoDestroy = 5f;
    [SerializeField] bool playOnStart = false;
    void Start() 
    {
        if(playOnStart) StartCoroutine(PlayAnimationAndDestroy());
    }

    public IEnumerator PlayAnimationAndDestroy()
    {
        if(playOnStart) yield return new WaitForSeconds(timeToAutoDestroy);
        gameObject.GetComponent<Animator>().Play("ArrowEnd");
        
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
