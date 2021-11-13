using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveInteraction : MonoBehaviour
{
    [SerializeField] private GameObject[] discoveries;
    [SerializeField] private Transform[] objectivesPoints;
    [SerializeField] private int objectivesReached;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "test")
        {
            collision.collider.gameObject.SetActive(false);
            objectivesReached++;
        }
        
        if (CheckAllObjectives())
            activateDiscovery();
    }

    // Check si tous les objectifs ont été atteints
    private bool CheckAllObjectives()
    {
        if (objectivesReached == objectivesPoints.Length)
        {
            return true;
        }
        return false;
    }

    // Permet d'activer/désactiver ce que l'on veut lorsque toutes les objectifs ont été atteints
    private void activateDiscovery()
    {
        foreach (GameObject child in discoveries)
        {
            child.SetActive(false);
        }
    }
}
