using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected string _name;
    protected string _description;
    //public UasgeCost;
    //public Sprite Icon;
    //public AudioClip Sound;
    protected float _cooldown;

    public abstract void TriggerAbility();
}