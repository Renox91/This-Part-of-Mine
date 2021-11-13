using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCamPos;
    [SerializeField] private Vector2 parallaxEffect;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCamPos = cameraTransform.position;
    }
    private void FixedUpdate()
    {
        Vector3 deltaMove = cameraTransform.position - lastCamPos;
        deltaMove *= parallaxEffect;
        lastCamPos = cameraTransform.position;
        transform.position = new Vector3(transform.position.x  + deltaMove.x * parallaxEffect.x, transform.position.y + deltaMove.y * parallaxEffect.y, transform.position.y);
    }
}
