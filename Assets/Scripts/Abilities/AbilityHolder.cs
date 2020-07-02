using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private string AbilityButtonName;
    [SerializeField] private Image CDMask;
    [SerializeField] private Text CDText;

    [SerializeField] IAbility ability;

    private float AbilityCD;
    private float CuttentAbilityCD;

    void Start()
    {
        Initialize(ability);
    }
    void Update()
    {
        
        //StartCoroutine("CoolDown");
    }
    public void Initialize(IAbility selectedAbility)
    {
        ability = selectedAbility;
    }
    //IEnumerator CoolDown()
    //{
    //    ability.TriggerAbility();
    //    yield return new WaitForSeconds(AbilityCD);
    //}
    private void AbilityReady()
    {
        CDText.enabled = false;
        CDMask.enabled = false;
    }
    private void CoolDown()
    {
        CuttentAbilityCD -= Time.deltaTime;
        float roundedCd = Mathf.Round(CuttentAbilityCD);
        CDText.text = roundedCd.ToString();
        CDMask.fillAmount = (CuttentAbilityCD / CuttentAbilityCD);
    }
}