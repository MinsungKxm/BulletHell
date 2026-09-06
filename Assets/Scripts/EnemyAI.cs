using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject player;

    public float moveSpeed = 3f;
    public float turnSpeed = 180f;

    public float minimumDistance = 5f;
    public float maximumDistance = 8f;

    void Update() {
        if (player == null) {
            return;
        }

        Vector3 direction =
            player.transform.position - transform.position;

        // Keeps the enemy level instead of tilting up or down.
        direction.y = 0f;

        float distance = direction.magnitude;

        RotateTowardPlayer(direction);
        MaintainDistance(direction, distance);
    }

    void RotateTowardPlayer(Vector3 direction) {
        if (direction == Vector3.zero) {
            return;
        }

        Quaternion targetRotation =
            Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );
    }

    void MaintainDistance(Vector3 direction, float distance) {
        if (distance > maximumDistance) {
            // Move toward the player.
            transform.position +=
                direction.normalized * moveSpeed * Time.deltaTime;
        } else if (distance < minimumDistance) {
            // Back away from the player.
            transform.position -=
                direction.normalized * moveSpeed * Time.deltaTime;
        }

        // Stay still when within the preferred distance range.
    }
}