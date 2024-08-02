using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarnningCircle : MonoBehaviour
{
    [SerializeField] private float _fadeTime;
    private SpriteRenderer _sp;

    private void Awake(){
        _sp = GetComponent<SpriteRenderer>();
        _sp.color = new Color(255f, 0, 0, 0.5f);
        InFade(_fadeTime);
    }
    
    private void InFade(float time){
        _sp.DOFade(0.9f, time).OnComplete(() =>{
            Destroy(gameObject);
        });
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.7f);
    }
}
