using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private bool _isAllDie;
    [SerializeField] private SpriteRenderer _buttonKey;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _buttonKey.gameObject.SetActive(true);
        _buttonKey.DOFade(1, 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManagement.Instance.LoadScene();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _buttonKey.DOFade(0, 0.5f);
        _buttonKey.gameObject.SetActive(true);
    }
}
