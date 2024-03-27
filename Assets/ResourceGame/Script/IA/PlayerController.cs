using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Places;
    //SteringBehaviour _sb;
    NewPathFollowing pathFollowing;
    //private NavMeshAgent mAgent;
    // Start is called before the first frame update
    void Start()
    {
        //mAgent = GetComponent<NavMeshAgent>();
        //_sb = GetComponent<SteringBehaviour>();
        pathFollowing = GetComponent<NewPathFollowing>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pathFollowing.pathPoints != null)
        {
            pathFollowing.NextPoint();
            //_sb.Arrive(pathFollowing.currentPoints);
        }
    }
    public void ChoosePlace(int index)
    {
        //transform.position = MovePlaces[index].transform.position;
    }

}
