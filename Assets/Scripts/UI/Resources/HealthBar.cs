using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scima.ResourceSystems;

public class HealthBar : MonoBehaviour
{
    HealthSystem _healthSystem;

    [SerializeField] Image _fill;
    [SerializeField] TextMeshProUGUI _text;

    void Start()
    {
        _healthSystem = Player.Instance.Health;
        _healthSystem.OnHealthUpdateCallback += UpdateHealthBar;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        _fill.fillAmount = _healthSystem.Percentage;
        _text.text = _healthSystem.GetCurrentOverMaximum();
    }
}
