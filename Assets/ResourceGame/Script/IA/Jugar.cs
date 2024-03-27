using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : State
{
    // Start is called before the first frame update

    void Start()
    {
        LoadComponent();
    }

    public override void LoadComponent()
    {
        
        base.LoadComponent();
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
            {
                RandomArray();
                index = index % arrayTime.Length;
            }

            h_health.sleep = Mathf.Clamp(h_health.sleep - UnityEngine.Random.Range(10, 20), 0, 100);
            if (h_health.sleep == 0&& h_health.jugar ==false && h_health.comer ==false && h_health.banno ==false)
            {
                Debug.Log("Me fui a dormir");
                m_MachineState.NextState(TypeState.Dormir);
                playerController.ChoosePlace(2);
                h_health.dormir = true;
            }


            h_health.hungry = Mathf.Clamp(h_health.hungry -  UnityEngine.Random.Range(5, 10), 0, 100);
            if (h_health.hungry == 0&& h_health.jugar == false && h_health.dormir == false && h_health.banno == false)
            {
                Debug.Log("Me fui a comer");
                m_MachineState.NextState(TypeState.Comer);
                playerController.ChoosePlace(1);
                h_health.comer = true;
            }

            return;
        }
        FrameRate += Time.deltaTime;
    }
    public override void Exit()
    {

    }
}
