using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    SteeringBehaviour _StreeringBehavior;
    PathFollowing _PathFollowing;
    public TypePath TestcurrentPath;
    // Start is called before the first frame update
    void Start()
    {
        _StreeringBehavior = GetComponent<SteeringBehaviour>();
        _PathFollowing = GetComponent<PathFollowing>();
        Debug.Log("SE INICIO 1 VEZ");
        _PathFollowing.ChangePath(TypePath.Jugar);
    }

    // Update is called once per frame
    void Update()
    {

        _StreeringBehavior.target = _PathFollowing.NextCurrentPointPath();
        _StreeringBehavior.Arrive();

    }
    public void Move(TypePath type)
    {
        _PathFollowing.ChangePath(type);


        

        Debug.Log("Me movi");
    }
}