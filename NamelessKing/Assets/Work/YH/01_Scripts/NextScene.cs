using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    private Image _fadeImage;
    private void Awake()
    {
        _fadeImage = GetComponent<Image>();
    }
    public void LoadNextScene()
    {
        SoundManager.Instance.StopSound();
        Debug.Log(1);
        _fadeImage.DOFade(1, 1f).OnComplete(() =>
        {
            SceneManagement.Instance.LoadScene();
        });
    }
}
