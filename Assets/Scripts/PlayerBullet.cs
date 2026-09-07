using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    public float speed = 5f;

    void Start() {
        IgnorePlayerCollisions();
    }

    void Update() {
        transform.Translate(
            Vector3.forward * speed
        );
    }

    void IgnorePlayerCollisions() {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null) {
            return;
        }

        Collider[] bulletColliders =
            GetComponentsInChildren<Collider>();

        Collider[] playerColliders =
            player.GetComponentsInChildren<Collider>();

        foreach (Collider bulletCollider in bulletColliders) {
            foreach (Collider playerCollider in playerColliders) {
                Physics.IgnoreCollision(
                    bulletCollider,
                    playerCollider
                );
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        EnemyAI enemy =
            other.GetComponentInParent<EnemyAI>();

        if (enemy != null) {
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
    }
}