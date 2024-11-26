using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipCutScene : MonoBehaviour
{
    [SerializeField] private float _cutSceneEndTime;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private GameObject _canvas;
    
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Skip());
    }

    public IEnumerator Skip(){
        _playableDirector.Resume();
        _canvas.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        
        _playableDirector.time = _cutSceneEndTime;
    }
}
