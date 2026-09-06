using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject projectile;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnProjectile", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnProjectile() {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
