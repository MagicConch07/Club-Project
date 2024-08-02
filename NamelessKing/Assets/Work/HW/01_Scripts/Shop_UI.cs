using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Shop_UI : MonoBehaviour
{
    private UIDocument _uiDocument;


    private VisualElement _rootVisualElement;
    private Button _settingButton; //세팅창 나가기 버튼

    private Button _buyBtn;

    private IStyle _buttonStyle;

    [SerializeField] private float _fontSize = 45f;
    [SerializeField] private float _targetFontSize = 50f;
    [SerializeField] private float _changeDuration = 1f;

    private VisualElement _windowBox;

    public Shop shop;

    private float _currentFontSize;
    private float _time;

    [SerializeField] private bool _isSetting = false; // 세팅창이 켜졌니?
    private bool isClicked;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }


    private void Start()
    {
        _windowBox.style.top = new Length(0, LengthUnit.Percent); //설정창을 안보이게
    }
    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;
        _rootVisualElement = root.Q<VisualElement>("shop-container");
        _buyBtn = _rootVisualElement.Q<Button>("buy-btn");
        _buttonStyle = _buyBtn.style;
        _currentFontSize = _fontSize;

        _settingButton = _rootVisualElement.Q<Button>("exit-btn");

        _windowBox = root.Q<VisualElement>("shop-window");


        _buyBtn.RegisterCallback<MouseCaptureEvent>((evt) =>
        {
            isClicked = true;
            ChangeFontSize();
        });

        _buyBtn.RegisterCallback<MouseCaptureOutEvent>((evt) =>
        {
            isClicked = false;
            ChangeFontSize();
        });

        _buyBtn.clicked += () =>
        {
            //아이템 사기
        };

        _settingButton.clicked += () =>
        {
            PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(false);
            _isSetting = false;
            _windowBox.style.top = new Length(0, LengthUnit.Percent); //설정창을 안보이게
        };
    }

    void ChangeFontSize()
    {
        _time = 0f;
        _time += Time.deltaTime;

        if (_time >= _changeDuration)
        {
            _currentFontSize = isClicked ? _targetFontSize : _fontSize;
            _time = 0f;
        }

        float t = Mathf.Clamp01(_time / _changeDuration);

        _buttonStyle.fontSize = Mathf.Lerp(isClicked ? _targetFontSize : _fontSize, _currentFontSize, t);
    }

    private void Update()
    {
        OnSettingWindow();
    }
    private void OnSettingWindow()
    {

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (shop != null)
                if (shop.isShop)
                    if (_isSetting)
                    {
                        PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(false);
                        _isSetting = false;
                        _windowBox.style.top = new Length(0, LengthUnit.Percent); //설정창을 안보이게
                    }
                    else if (!_isSetting)
                    {
                        PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(true);
                        _isSetting = true;
                        _windowBox.style.top = new Length(100, LengthUnit.Percent); // 설정창을 보이게
                    }
        }
    }
}
