using UnityEngine;

public interface IAbility
{
    string Name { get; set; }
    string Description { get; set; }
    //protected UasgeCost;
    //protected Sprite Icon;
    //protected AudioClip Sound;
    float CoolDown { get; set; }

    void TriggerAbility();
}