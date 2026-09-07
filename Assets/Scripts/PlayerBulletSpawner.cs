using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBulletSpawner : MonoBehaviour {
    public GameObject playerBulletPrefab;

    void Update() {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame) {
            FireBullet();
        }
    }

    void FireBullet() {
        Instantiate(
            playerBulletPrefab,
            transform.position,
            transform.rotation
        );
    }
}