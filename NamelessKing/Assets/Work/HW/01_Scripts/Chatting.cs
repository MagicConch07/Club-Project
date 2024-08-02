using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chatting : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _chatting;
    private Label _chattingLabel;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;

        _chatting = root.Q<VisualElement>("chatting");
        _chattingLabel = root.Q<Label>("chatting-label");

    }

    private void Update()
    {

    }


}
