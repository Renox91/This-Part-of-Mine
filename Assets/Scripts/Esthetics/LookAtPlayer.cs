using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform leftEye;
    [SerializeField] private Transform rightEye;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (player.position.x >= leftPoint.position.x && player.position.x <= rightPoint.position.x)
        {
            float ratio = (player.position.x - leftPoint.position.x) / (rightPoint.position.x - leftPoint.position.x);
            float newX = leftEye.position.x + ratio * (rightEye.position.x - leftEye.position.x);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
