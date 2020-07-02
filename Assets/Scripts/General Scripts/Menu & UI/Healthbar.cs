using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthbar;
    [SerializeField] private float _updateSpeed = 0.1f;

    void Awake()
    {
        GetComponentInParent<Health>().OnHealthChanged += HealthChange;
    }

    private void HealthChange(float pct)
    {
        StartCoroutine(ChangeHealthbar(pct));
    }
    private IEnumerator ChangeHealthbar(float pct)
    {
        float HealthbarBefore = _healthbar.fillAmount;
        float elapsed = 0f;

        while (elapsed < _updateSpeed)
        {
            elapsed += Time.deltaTime;
            _healthbar.fillAmount = Mathf.Lerp(HealthbarBefore, pct, elapsed / _updateSpeed);
            yield return null;
        }

        _healthbar.fillAmount = pct;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
