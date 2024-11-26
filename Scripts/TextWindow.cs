using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TextWindow : MonoBehaviour
{
    [SerializeField] private TextSO _textInfo;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private TextMeshProUGUI _infoText,_nameText;
    private CanvasGroup _textImage;
    private int _currentText = 0;
    private bool _isPlaying;

    private void OnEnable()
    {
        _textImage = GetComponent<CanvasGroup>();
    }


    public void TextOn()
    {
        _isPlaying = true;
        _textImage.DOFade(1, 0.5f);
        _textImage.blocksRaycasts = true;
        _textImage.interactable = true;
        _playableDirector.Pause();
        SoundManager.Instance.StartTextSoruce();
        _nameText.text = _textInfo.text[_currentText].Name;
        _nameText.text.Replace("\\n", "\n");
        _infoText.DOText(_textInfo.text[_currentText].Info, 2.5f).OnComplete(() =>
        {
            _isPlaying = false;
        });
        ++_currentText;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isPlaying)
        {
            _textImage.DOFade(0, 0.5f);
            _textImage.blocksRaycasts = false;
            _textImage.interactable = false;
            _nameText.text = " ";
            _infoText.text = " ";
            _playableDirector.Play();
        }
    }
}
