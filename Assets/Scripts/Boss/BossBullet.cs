using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private GameObject grenDamTrigger;
    [SerializeField] private GameObject EnemyShoot;
    [SerializeField] private GameObject EnemyMelee;

    private float bulletSpeed = 8500;
    public bool hit;
    private bool hasExploded;


    public float explosionForce = 100;
    public float explosionRadius = 100;

    [SerializeField] private GameObject Tankbullet;
    void Update() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed * Time.deltaTime;       
    }

    private void OnCollisionEnter(Collision collision) {
        Vector3 ExploPos = gameObject.transform.position;
        var cloneTrigger = Instantiate(grenDamTrigger, ExploPos, transform.rotation);
        //Insert Audio of explosion
        hasExploded = true;
        Collider[] colliders = Physics.OverlapSphere(ExploPos, explosionRadius);
        foreach (Collider hit in colliders) {
            if (hit.transform.CompareTag("Enemy")) {
                if (hit.transform.TryGetComponent<Healthsystem>(out Healthsystem tankExplo)) {
                    tankExplo.RemoveHealthEnExplo();
                }
                Debug.Log("enemy Damaged: tank");
            }
            else if (hit.transform.TryGetComponent<PlayerHealthScript>(out PlayerHealthScript pl)) {
                pl.RemoveHealth();
                Debug.Log("player damaged: tank");
            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce, ExploPos, explosionRadius, 5);
                hasExploded = true;
                if (hasExploded == true) {
                    hasExploded = false;
                }
            }
        }
        Destroy(cloneTrigger);
        Destroy(gameObject);
    }
}
