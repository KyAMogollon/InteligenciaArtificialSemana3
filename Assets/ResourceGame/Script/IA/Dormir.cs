using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : State
{
    void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        RandomArray();
        base.LoadComponent();
    }
    // Update is called once per frame
    void Update()
    {
        Execute();

    }
    public override void Enter()
    {
        FrameRate = 0;
    }
    public override void Execute()
    {
        if (FrameRate > arrayTime[index])
        {
            FrameRate = 0;
            index++;
            if (index == arrayTime.Length)
                RandomArray();
            index = index % arrayTime.Length;
            //if (playerController.transform.position.x == playerController.Places[2].transform.position.x && playerController.transform.position.z == playerController.Places[2].transform.position.z)
            //{
                Debug.Log("Entre a dormir");
                h_health.sleep = Mathf.Clamp(h_health.sleep + UnityEngine.Random.Range(10, 20), 0, 100);
                if (h_health.sleep == 100)
                {
                    m_MachineState.NextState(TypeState.Jugar);
                    playerController.ChoosePlace(0);
                    h_health.dormir = false;

                }
                h_health.hungry = Mathf.Clamp(h_health.hungry - UnityEngine.Random.Range(20, 30), 0, 100);
                if (h_health.hungry == 0 && h_health.jugar == false && h_health.dormir == false && h_health.banno == false)
                {
                    m_MachineState.NextState(TypeState.Comer);
                    playerController.ChoosePlace(1);
                    h_health.comer = true;

                }
            //}   
            return;
        }
        FrameRate += Time.deltaTime;
    }
    public override void Exit()
    {

    }
}
