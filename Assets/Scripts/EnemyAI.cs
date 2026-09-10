using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private GameObject player;
/*
 
 */
    public float moveSpeed = 3f;
    public float turnSpeed = 180f;

    public float minimumDistance = 5f;
    public float maximumDistance = 8f;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) {
            Debug.LogError(
                "EnemyAI could not find a GameObject tagged Player."
            );
        }
    }

    void Update() {
        if (player == null) {
            return;
        }

        Vector3 direction =
            player.transform.position - transform.position;

        direction.y = 0f;

        float distance = direction.magnitude;

        RotateTowardsPlayer(direction);
        MoveTowardsPlayer(direction, distance);
    }

    void RotateTowardsPlayer(Vector3 direction) {
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

    void MoveTowardsPlayer(
        Vector3 direction,
        float distance
    ) {
        if (distance > maximumDistance) {
            transform.position +=
                direction.normalized *
                moveSpeed *
                Time.deltaTime;
        } else if (distance < minimumDistance) {
            transform.position -=
                direction.normalized *
                moveSpeed *
                Time.deltaTime;
        }
    }
}