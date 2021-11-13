using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parentize : MonoBehaviour
{
    [SerializeField] BoxCollider2D m_Collider;
    [SerializeField] float m_MaxDistance;

    private void Update()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    /*private void checkTopToParentize()
    {
        Raycast2D m_Hit;
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
        if (m_HitDetect)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + m_Hit.collider.name);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(var _collision in collision.contacts)
        {
            if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Stone"))
            {
                if (_collision.normal.y < 0)
                {
                    collision.transform.SetParent(transform);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
