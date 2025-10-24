using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharStatPanelHandler : MonoBehaviour
{
    public Character character;
    //public Health _Health;

    [Header("View")]
    [SerializeField] Slider _HealthSlider;
    [SerializeField] TMP_Text _apText;

    private void Awake()
    {
        //_Health = character.health;
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        character.health.ResourceChanged += OnHealthChanged;
        character.ap.ResourceChanged += OnApChanged;
        _HealthSlider.maxValue = character.health.MaxValue;
        _HealthSlider.value = character.health.CurrentValue;
        UpdateApView();
    }

    private void OnDestroy()
    {
        character.health.ResourceChanged -= OnHealthChanged;
        character.ap.ResourceChanged -= OnApChanged;
    }

    public void UpdateHealthView()
    {
        if (character.health == null)
            return;

        if (character.health.MaxValue != 0)
        {
            _HealthSlider.value = character.health.CurrentValue;
            //_HealthSlider.value = (character.health.CurrentHealth / character.health.MaxHealth) * 100f;
        }
    }

    private void OnHealthChanged()
    {
        UpdateHealthView();
    }

    public void UpdateApView()
    {
        _apText.text = $"{character.ap.CurrentValue} / {character.ap.MaxValue}";
    }
    private void OnApChanged()
    {
        UpdateApView();
    }
}
