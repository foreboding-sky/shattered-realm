using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    DealDamage(enemy);
                    Debug.Log("dealing damage");
                }
            }
        }
        void DealDamage(EnemyHealth health)
        {
            float damage = Random.Range(minDamage, maxDamage);
            health.TakeDamage(damage);
        }
    }
}
