using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeState { Comer,Jugar,Banno,Dormir}
public class State : MonoBehaviour
{
    protected float FrameRate;
    [SerializeField]
    protected float[] arrayTime ;
    [SerializeField]
    protected int index = 0;
    public TypeState type;
    public MachineState m_MachineState;
    public Health h_health;
    public Test playerController;
    protected void RandomArray()
    {
        for (int i = 0; i < arrayTime.Length; i++)
        {
            arrayTime[i] = UnityEngine.Random.Range(2, 4);
        }
    }
    public virtual void LoadComponent()
    {
        FrameRate = 0;
        arrayTime = new float[10];
        m_MachineState = GetComponent<MachineState>();
        h_health = GetComponent<Health>();
        playerController = GetComponent<Test>();
        RandomArray();
    }
    public virtual void Enter( )
    {
        FrameRate = 0;
    }
    public virtual void Execute()
    {

    }
    public virtual void Exit()
    {

    }
}
