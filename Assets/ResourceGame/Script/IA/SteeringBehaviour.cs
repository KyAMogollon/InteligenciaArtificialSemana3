using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
     public Transform target; // El objeto al que queremos llegar
    public float maxSpeed = 5f; // Velocidad m�xima del objeto
    public float slowingDistance = 5f; // Distancia a partir de la cual el objeto comenzar� a desacelerar
    public float stoppingDistance = 1f; // Distancia a partir de la cual el objeto se detendr�
    // Start is called before the first frame update
     
    public void Arrive( )
    {
        // Calcula la direcci�n hacia el objetivo
        Vector3 targetDirection = target.position - transform.position;

        // Calcula la distancia al objetivo
        float distance = targetDirection.magnitude;

        // Calcula la velocidad deseada
        float desiredSpeed = maxSpeed;

        // Si estamos dentro de la distancia de frenado, ajusta la velocidad
        if (distance < slowingDistance)
        {
            desiredSpeed = maxSpeed * (distance / slowingDistance);
        }

        // Si estamos dentro de la distancia de parada, det�n completamente
        if (distance < stoppingDistance)
        {
            desiredSpeed = 0f;
        }


        // Calcula la fuerza de direcci�n hacia la velocidad deseada
        transform.rotation = Quaternion.LookRotation(targetDirection.normalized);

        transform.position += transform.forward * Time.deltaTime * desiredSpeed;
    }
}
