using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Setting : MonoBehaviour
{
    private UIDocument _uiDocument;

    private VisualElement _rootVisualElement;

    private VisualElement _windowBox;
    private Button _settingButton; //����â ������ ��ư
    private Button _gameButton; //���� ���� ��ư
    private Slider _totalSound;
    //[SerializeField] private Sprite _gameSprite;
    private Slider _bgSound;
    private Slider _effectSound;

    [SerializeField] private bool _isSetting = false; // ����â�� ������?

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;
        _rootVisualElement = root.Q<VisualElement>("setting-container");

        _windowBox = _rootVisualElement.Q<VisualElement>("setting-window"); //����â
        _windowBox.style.top = new Length(0, LengthUnit.Percent);

        _settingButton = _rootVisualElement.Q<Button>("exit-btn");
        _gameButton = _rootVisualElement.Q<Button>("game-exit-btn");

        _totalSound = _rootVisualElement.Q<Slider>("total-sound");

        _bgSound = _rootVisualElement.Q<Slider>("bg-sound");
        _effectSound = _rootVisualElement.Q<Slider>("effect-sound");



        _totalSound.RegisterValueChangedCallback((evt) =>
        {
            Debug.Log(evt.newValue);
            SoundManager.Instance.SetTotalValue(evt.newValue);
        });
        _bgSound.RegisterValueChangedCallback((evt) =>
        {
            SoundManager.Instance.SetMusicValue(evt.newValue);
        });

        _effectSound.RegisterValueChangedCallback((evt) =>
        {
            SoundManager.Instance.SetEffectValue(evt.newValue);
        });



        _settingButton.clicked += () =>
        {
            PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(false);
            _isSetting = false;
            _windowBox.style.top = new Length(0, LengthUnit.Percent);
        };

        _gameButton.clicked += () =>
        {
            Application.Quit();
        };
    }

    private void Update()
    {
        OnSettingWindow();
    }
    void OnSettingWindow()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (_isSetting)
            {
                PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(false);
                _isSetting = false;
                _windowBox.style.top = new Length(0, LengthUnit.Percent); //����â�� �Ⱥ��̰�
            }
            else if (!_isSetting)
            {
                PlayerManager.Instance.Player.PlayerMovementCompo.NoInput(true);
                _isSetting = true;
                _windowBox.style.top = new Length(100, LengthUnit.Percent); // ����â�� ���̰�
            }
        }
    }
}
