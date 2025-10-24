using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [Header("Model")]
    Resource _Health;

    [Header("View")]
    [SerializeField] Slider _HealthSlider;

    private void Awake()
    {
        //_HealthSlider = GetComponentInChildren<Slider>();
    }
    private void Start()
    {
        _Health.ResourceChanged += OnHealthChanged;
        _HealthSlider.maxValue = _Health.MaxValue;
    }

    private void OnDestroy()
    {
        _Health.ResourceChanged -= OnHealthChanged;
    }

    public void UpdateView()
    {
        if (_Health == null)
            return;

        if(_Health.MaxValue != 0)
        {
            _HealthSlider.value = (_Health.CurrentValue / _Health.MaxValue) * 100f;
        }


    }

    private void OnHealthChanged()
    {
        UpdateView();
    }
}
