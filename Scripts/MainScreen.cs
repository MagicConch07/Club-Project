using DG.Tweening;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainScreen : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _fadeElement;
    private Button _startButton;
    private IStyle _buttonStyle;

    [SerializeField] private UnityEngine.UI.Image _image;

    [SerializeField] private float _fontSize = 45f;
    [SerializeField] private float _targetFontSize = 50f;
    [SerializeField] private float _changeDuration = 1f;

    private float _currentFontSize;
    private float _time;

    private bool isClicked = false;

    private float _startTime;
    public float targetOpacity = 0f;
    public float duration = 1.0f;
    private float startOpacity;



    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void Start()
    {
        _startTime = Time.time;
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;
        _fadeElement = root.Q<VisualElement>("start-container");
        startOpacity = _fadeElement.style.opacity.value;
        _startButton = root.Q<Button>("start-btn");
        _buttonStyle = _startButton.style;
        _currentFontSize = _fontSize; // �ʱ� ��Ʈ ũ�� ����
    }

    private void Update()
    {
        ChangeFontSize();
        AnyKeyPressed();

        if (isClicked)
        {
            isClicked = false;
            _fadeElement.style.opacity = 0;
        }
    }

    void ChangeFontSize()
    {
        _time += Time.deltaTime;


        if (_time >= _changeDuration)
        {
            _time = 0f;

            _currentFontSize = _currentFontSize == _fontSize ? _targetFontSize : _fontSize;
        }

        float t = Mathf.Clamp01(_time / _changeDuration);


        _buttonStyle.fontSize = Mathf.Lerp(_currentFontSize == _fontSize ? _targetFontSize : _fontSize, _currentFontSize, t);
    }

    void AnyKeyPressed()
    {
        if (Input.anyKeyDown && !isClicked)
        {
            isClicked = true;
            _image.DOFade(1, 3).OnComplete(() =>{
                ChangeScene();
            });
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StartCutScene");
    }
}