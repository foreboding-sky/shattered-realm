using UnityEngine;

public abstract class Ability : ScriptableObject
{
    protected string Name = "New Ability";
    protected string Description = "This is an ability!";
    //protected UasgeCost;
    protected Sprite Icon;
    protected AudioClip Sound;
    protected float BaseCoolDown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}