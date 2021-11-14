using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucioleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-5, 0)]
    [SerializeField] private float negativeXDelta;
    [Range(-5, 0)]
    [SerializeField] private float negativeYDelta;
    [Range(0, 5)]
    [SerializeField] private float positiveXDelta;
    [Range(0, 5)]
    [SerializeField] private float positiveYDelta;

    [SerializeField] private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posDestination = new Vector2(Random.Range(negativeXDelta, positiveXDelta), Random.Range(negativeYDelta, positiveYDelta));
        transform.position = Vector3.Lerp(transform.position, posDestination, 0.2f);
    }
}
