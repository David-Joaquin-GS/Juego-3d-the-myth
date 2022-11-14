using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir_Personaje : MonoBehaviour
{

    public Transform Objetivo;
    public float velocidad;
    public NavMeshAgent IA;

    // Update is called once per frame
    void Update()
    {

        IA.speed = velocidad;
        IA.SetDestination(Objetivo.position);
        
    }
}
