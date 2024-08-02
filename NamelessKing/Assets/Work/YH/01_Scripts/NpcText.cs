using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;

public class NpcText : MonoBehaviour
{
    [SerializeField] private TextSO _textInfo;
    [SerializeField] private TextMeshProUGUI _infoText, _nameText;
    [SerializeField] private SpriteRenderer _buttonKey;
    [SerializeField] private Image _clickBtnImage;
    [SerializeField] private CanvasGroup _textImage;
    private int _currentText = 0;
    [SerializeField] private bool _isPlaying,_textOn;

    private void OnText()
    {
        _isPlaying = true;
        _textOn = true;
        PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(true);
        _clickBtnImage.DOFade(0, 0);
        _textImage.DOFade(1, 0.5f);
        _textImage.blocksRaycasts = true;
        _textImage.interactable = true;
        //SoundManager.Instance.StartTextSoruce();
        _nameText.text = _textInfo.text[_currentText].Name;
        _infoText.DOText(_textInfo.text[_currentText].Info, 2.5f).OnComplete(() =>
        {
            _clickBtnImage.DOFade(1, 0.5f);
            _isPlaying = false;
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _buttonKey.gameObject.SetActive(true);
        _buttonKey.DOFade(1, 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnText();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _buttonKey.DOFade(0, 0.5f);
        _buttonKey.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) &&!_isPlaying &&_textOn)
        {
            _nameText.text = "";
            _infoText.text = "";
            _textImage.blocksRaycasts = false;
            _textImage.interactable = false;
            _textOn = false;
            PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(false);
            _textImage.DOFade(0, 0.5f);
        }
    }

}
