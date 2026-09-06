using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;

    private Vector3 localOffset;
    private Quaternion rotationOffset;

    void Start() {
        localOffset = player.InverseTransformPoint(transform.position);

        rotationOffset =
            Quaternion.Inverse(player.rotation) * transform.rotation;
    }

    void LateUpdate() {
        if (player != null) {
            transform.position = player.TransformPoint(localOffset);
            transform.rotation = player.rotation * rotationOffset;
        }
    }
}