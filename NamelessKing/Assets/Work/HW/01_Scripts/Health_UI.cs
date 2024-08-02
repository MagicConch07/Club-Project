using UnityEngine;
using UnityEngine.UIElements;

public class Health_UI : MonoSingleton<Health_UI>
{


    private UIDocument _uiDocument;

    private VisualElement _rootVisualElement;
    private VisualElement _pollution;
    private Label _pollutionLabel;

     private float _maxHealth = 200;
     private float _currentHealth;

    private new void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _pollution.style.flexBasis = new Length(_currentHealth, LengthUnit.Percent);
        _pollutionLabel.text = $"{_currentHealth}/{_maxHealth}";
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;

        _rootVisualElement = root.Q<VisualElement>("health-container");

        _pollution = _rootVisualElement.Q<VisualElement>("pollution-bar");
        _pollutionLabel = _rootVisualElement.Q<Label>("pollution-label");
    }

    public void OnHit(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, 200);
        _pollution.style.flexBasis = new Length(_currentHealth / (_maxHealth / 100), LengthUnit.Percent);
        Debug.Log(_currentHealth / (_maxHealth / 100));
        _pollutionLabel.text = $"{_currentHealth}/{_maxHealth}";
    }
}
