using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlatform : MonoBehaviour
{
    [SerializeField] private float temporalOffset;
    private bool canMove;
    [SerializeField] private Transform rotationCenter;
    [SerializeField] private float rotationRadius = 2f;
    private float angularSpeed;
    [SerializeField] private float angularSpeedMultiply;
    [SerializeField] private float startAngle, endAngle;
    private float miAngle;
    private float posX, posY, angle = 0.0f;
    private void Start()
    {
        Invoke("Init", temporalOffset);
        miAngle = (startAngle + endAngle) / 2;
    }
    private void Update()
    {
        if(!canMove)
        {
            return;
        }
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;
        angularSpeed = Mathf.Sign(angularSpeed) * Mathf.Max(0.3f,(1 - Mathf.Abs((angle + miAngle)/miAngle))) * angularSpeedMultiply;
        if (angle > startAngle)
        {
            angularSpeed *= -1;
            angle = startAngle;
        }
        else if (angle < -endAngle)
        {
            angularSpeed *= -1;
            angle = -endAngle;
        }
    }
    private void Init()
    {
        canMove = true;
    }
}
