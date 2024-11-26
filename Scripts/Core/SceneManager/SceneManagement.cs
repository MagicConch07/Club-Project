using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq.Expressions;
using UnityEngine.UI;

public enum StageEnum{
    Start,
    StartCutScene,
    CutScene,
    Stage1,
    Satage2,
    Lobby,
}

public class SceneManagement : MonoSingleton<SceneManagement>
{
    [SerializeField] private SceneDataSO sceneData;
    [SerializeField] private Transform _nameTrm;
    [SerializeField] private TextMeshProUGUI _infoName;
    private TextMeshProUGUI _mapName;   
    private float delay = 2.5f;
    private int sceneNumber = 1;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        // if(sceneNumber == 0){
        //     sceneNumber = 1;
        // }

        _mapName = _nameTrm.GetComponentInChildren<TextMeshProUGUI>();
        SceneManager.sceneLoaded += MapInfoView;
    }

    private void MapInfoView(Scene arg0, LoadSceneMode arg1)
    {
        if (sceneNumber == 1 || arg0.name != $"Stage{arg0.buildIndex - 3}") return;
        _mapName.text = sceneData.info[sceneNumber].Name;
        _infoName.text = sceneData.info[sceneNumber].Info;
        Sequence seq = DOTween.Sequence();
        seq.Append(_nameTrm.DOLocalMoveY(400f, 1.5f, true));
        seq.Join(_infoName.transform.DOLocalMoveY(270f, 1.5f, true));
        seq.Append(_mapName.DOFade(1, 0.5f));
        seq.Append(_infoName.DOFade(1, 0.5f));
        seq.AppendInterval(delay);
        seq.Append(_mapName.DOFade(0, 0.5f));
        seq.Join(_infoName.DOFade(0, 0.5f));
        seq.Append(_nameTrm.DOLocalMoveY(660f, 1.5f, true));
        seq.Join(_infoName.transform.DOLocalMoveY(570f, 1.5f, true));
    }

    public void LoadScene()
    {
        ++sceneNumber;
        Debug.Log(sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }
}
