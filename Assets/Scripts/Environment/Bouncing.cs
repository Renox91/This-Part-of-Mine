using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    [SerializeField] private int bouncePower;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Collision champi");
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bouncePower));
        }
    }
}
