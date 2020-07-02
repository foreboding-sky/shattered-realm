using UnityEngine;

public class Spell : MonoBehaviour, IAbility
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public Camera cam;

    public string Name { get; set; }
    public string Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float CoolDown { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void TriggerAbility()
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
        Name = "Spell";
        Description = "A simple spell";
        CoolDown = 1f;
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
