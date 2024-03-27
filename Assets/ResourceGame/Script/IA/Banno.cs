using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banno : State
{
    // Start is called before the first frame update
    
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

            

            //if(playerController.transform.position.x == playerController.Places[3].transform.position.x && playerController.transform.position.z == playerController.Places[3].transform.position.z)
            //{
                h_health.sleep = Mathf.Clamp(h_health.sleep - UnityEngine.Random.Range(5, 10), 0, 100);
                if (h_health.sleep == 0 && h_health.jugar == false && h_health.comer == false && h_health.banno == false)
                {
                    m_MachineState.NextState(TypeState.Dormir);
                    playerController.ChoosePlace(2);
                    h_health.dormir = true;
                }

                h_health.wc = Mathf.Clamp(h_health.wc - UnityEngine.Random.Range(20, 30), 0, 100);
                if (h_health.wc == 0)
                {
                    m_MachineState.NextState(TypeState.Jugar);
                    playerController.ChoosePlace(0);
                    h_health.banno = false;
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
