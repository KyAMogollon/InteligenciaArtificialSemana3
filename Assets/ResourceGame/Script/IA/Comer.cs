using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : State
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

            
                h_health.sleep = Mathf.Clamp(h_health.sleep - UnityEngine.Random.Range(1, 10), 0, 100);
                if (h_health.sleep == 0 && h_health.jugar == false && h_health.comer == false && h_health.banno == false)
                {
                    m_MachineState.NextState(TypeState.Dormir);
                    playerController.Move(TypePath.Dormir);
                    h_health.dormir = true;
                }

                h_health.hungry = Mathf.Clamp(h_health.hungry + UnityEngine.Random.Range(10, 20), 0, 100);
                if (h_health.hungry == 100)
                {
                    
                    m_MachineState.NextState(TypeState.Jugar);
                    playerController.Move(TypePath.Jugar);
                    h_health.comer = false;
                }

                h_health.wc = Mathf.Clamp(h_health.wc + UnityEngine.Random.Range(5, 10), 0, 100);
                if (h_health.wc == 100 && h_health.jugar == false && h_health.comer == false && h_health.dormir == false)
                {

                    m_MachineState.NextState(TypeState.Banno);
                    playerController.Move(TypePath.WC);
                    h_health.banno = true;

                }
            return;
        }
        FrameRate += Time.deltaTime;
    }
    public override void Exit()
    {

    }
}
