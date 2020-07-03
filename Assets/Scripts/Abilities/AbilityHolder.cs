using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private string _abilityButtonName;
    [SerializeField] private Image _CDMask;
    [SerializeField] private Text _CDText;

    [SerializeField] private Ability _ability;

    private float _abilityCD;
    private float _cuttentAbilityCD;

    void Start()
    {
        Initialize(_ability);
    }
    void Update()
    {
        
        //StartCoroutine("CoolDown");
    }
    public void Initialize(Ability selectedAbility)
    {
        _ability = selectedAbility;
    }
    //IEnumerator CoolDown()
    //{
    //    ability.TriggerAbility();
    //    yield return new WaitForSeconds(AbilityCD);
    //}
    private void AbilityReady()
    {
        _CDText.enabled = false;
        _CDMask.enabled = false;
    }
    private void CoolDown()
    {
        _cuttentAbilityCD -= Time.deltaTime;
        float roundedCd = Mathf.Round(_cuttentAbilityCD);
        _CDText.text = roundedCd.ToString();
        _CDMask.fillAmount = (_cuttentAbilityCD /_cuttentAbilityCD);
    }
}