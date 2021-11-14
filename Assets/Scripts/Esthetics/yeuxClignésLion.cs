using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeuxClignésLion : MonoBehaviour
{
    [SerializeField]
    private GameObject yeuxClosLion;
    [SerializeField]
    private float dureeYeuxFermes;
    private float timerYeuxFermes;

    private float tempsYeuxOuverts;
    // Start is called before the first frame update
    void Start()
    {
        tempsYeuxOuverts = Random.Range(2f,6f);
    }

    // Update is called once per frame
    void Update()
    {
        tempsYeuxOuverts -= Time.deltaTime;
        timerYeuxFermes -= Time.deltaTime;
        if (tempsYeuxOuverts < 0f) 
        {
            yeuxClosLion.SetActive(true);
            tempsYeuxOuverts = Random.Range(3f,8f);
            timerYeuxFermes = dureeYeuxFermes;
        }else if (timerYeuxFermes < 0f)
        {
            yeuxClosLion.SetActive(false);
            timerYeuxFermes = 10f;
        }
    }
}
