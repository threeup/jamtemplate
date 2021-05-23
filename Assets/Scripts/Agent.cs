
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AgentState
{
    NACENT,
    ACTIVE,
    DISABLED,
}


public class Agent : MonoBehaviour
{
    public string Name = "Agent";
    public StateMachine<ProgramState> Machine = new StateMachine<ProgramState>();

    void Awake()
    {
        Machine.Initialize(this);

        Boss.Instance.RegisterAgent(this);
    }

    void Start()
    {
        Machine.Begin();
    }
}