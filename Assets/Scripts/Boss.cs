using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    INACTIVE,
    ACTIVE,
}

public class Boss : LazySingletonBehaviour<Boss>
{
    public List<Agent> Agents = new List<Agent>();
    public StateMachine<BossState> Machine = new StateMachine<BossState>();


    // Start is called before the first frame update
    void Awake()
    {
        Machine.Initialize(this);
        BossInactiveState.Bind(Machine[BossState.INACTIVE]);
        BossActiveState.Bind(Machine[BossState.ACTIVE]);

        Machine.AdvanceMap[BossState.INACTIVE] = BossState.ACTIVE;
        Machine.WithdrawMap[BossState.ACTIVE] = BossState.INACTIVE;
    }
    void Start()
    {
        Machine.Begin();
    }

    public void RegisterAgent(Agent inAgent)
    {
        Agents.Add(inAgent);
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Machine.MachineUpdate(dt);
    }
}
