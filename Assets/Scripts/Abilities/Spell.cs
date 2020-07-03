using UnityEngine;

public class Spell : Ability
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public Camera cam;
    public new string _name = "Spell";
    public new string _description = "A simple spell";
    public new float _cooldown = 2f;

    public override void TriggerAbility()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                DealDamage(enemy);
                Debug.Log("dealing damage");
            }
        }
    }

    void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TriggerAbility();
        }
    }
    void DealDamage(EnemyHealth health)
    {
        float damage = Random.Range(minDamage, maxDamage);
        health.TakeDamage(damage);
    }
}
