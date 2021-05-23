
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AgentState
{
    NACENT,
    ACTIVE,
    DISABLED,
}


public class Agent : Controller
{
    public string Name = "Agent";
    public StateMachine<ProgramState> Machine = new StateMachine<ProgramState>();

    public override void Awake()
    {
        base.Awake();
        Machine.Initialize(this);
        Boss.Instance.Agents.Add(this);
    }

    public override void Die()
    {
        Program.Instance.Controllers.Remove(this);
        Boss.Instance.Agents.Remove(this);
        Destroy(this.gameObject);
    }

    void Start()
    {
        Machine.Begin();
    }

    public override void Update()
    {
        base.Update();
        if(ControlledPawn)
        {
            ControlledPawn.SetVelocity(new Vector3(-1,0,0));
        }
    }
}