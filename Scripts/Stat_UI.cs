using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Stat_UI : MonoBehaviour
{


    private UIDocument _uiDocument;

    private VisualElement _rootVisualElement;

    private VisualElement _statWindow;

    private Button _exitbtn;

    private Button _health;
    private Button _strength;
    private Button _agility;

    private Label _healthLabel;
    private Label _strengthLabel;
    private Label _agilityLabel;


    public int _healthCount = 0;
    public int _strengthCount = 0;
    public int _agilityCount = 0;
    private bool _isSetting;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;
        _rootVisualElement = root.Q<VisualElement>("stat-container");
        _statWindow = _rootVisualElement.Q<VisualElement>("stat-window");

        _statWindow.style.top = new Length(0, LengthUnit.Percent);



        _health = _rootVisualElement.Q<Button>("health-btn");
        _strength = _rootVisualElement.Q<Button>("strength-btn");
        _agility = _rootVisualElement.Q<Button>("agility-btn");

        _healthLabel = _rootVisualElement.Q<Label>("health-label");
        _strengthLabel = _rootVisualElement.Q<Label>("streagth-label");
        _agilityLabel = _rootVisualElement.Q<Label>("agility-label");

        _healthLabel.text = $"{_healthCount}";
        _strengthLabel.text = $"{_strengthCount}";
        _agilityLabel.text = $"{_agilityCount}";

        ButtonClicked();

    }


    void ButtonClicked()
    {
        _health.clicked += () =>
        {
            _healthLabel.text = $"{++_healthCount}";
        };

        _strength.clicked += () =>
        {
            _strengthLabel.text = $"{++_strengthCount}";
        };

        _agility.clicked += () =>
        {
            _agilityLabel.text = $"{++_agilityCount}";
        };
    }

    private void Update()
    {
        //OnSettingWindow();
    }
    void OnSettingWindow()
    {
        if (_isSetting)
        {
            _isSetting = false;
            _statWindow.style.top = new Length(0, LengthUnit.Percent); //설정창을 안보이게
        }
        else if (!_isSetting)
        {
            _isSetting = true;
            _statWindow.style.top = new Length(100, LengthUnit.Percent); // 설정창을 보이게
        }
    }
}

