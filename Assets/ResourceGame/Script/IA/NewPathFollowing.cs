using UnityEngine;
using System.Collections.Generic;

public class NewPathFollowing : MonoBehaviour
{
    public List<Transform> pathPoints;
    //public float speed = 5f;
    //public float SpeedRotation = 5f;
    public float arrivalDistance = 0.1f;
    public Transform currentPoints;

    private int currentPointIndex = 0;
    public bool loop;

    public bool IsDrawGizmo;
    public Color ColorGizmoPath;
    public Color ColorGizmoCurrentPoint;
    private void Start()
    {
        currentPoints = pathPoints[0];
    }
    public void NextPoint()
    {
        if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) < arrivalDistance)
        {
            // Avanzar al siguiente punto de la ruta
            currentPointIndex++;
            if (loop)
                currentPointIndex = currentPointIndex % pathPoints.Count;
            else
                currentPointIndex = Mathf.Clamp(currentPointIndex, 0, pathPoints.Count - 1);
            currentPoints = pathPoints[currentPointIndex];
        }
    }

    private void OnDrawGizmos()
    {
        if (!IsDrawGizmo) return;

        if (currentPoints != null)
        {
            Gizmos.color = ColorGizmoCurrentPoint;
            Gizmos.DrawSphere(currentPoints.position, 0.8f);
        }
        Gizmos.color = ColorGizmoPath;
        for (int i = 0; i < pathPoints.Count - 1; i++)
        {
            Gizmos.DrawWireSphere(pathPoints[i].position, 0.5f);

            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }

        Gizmos.DrawWireSphere(pathPoints[pathPoints.Count - 1].position, 0.5f);

    }

}