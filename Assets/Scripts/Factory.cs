using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : LazySingletonBehaviour<Factory>
{
    public GameObject ProtoCube;
    public GameObject ProtoCapsule;
    public GameObject ProtoCone;

    public void Launch(string inParams)
    {
        
    }

    public GameObject SpawnCube(Vector3 pos)
    {
        GameObject go = GameObject.Instantiate(ProtoCube, pos, Quaternion.identity);
        return go;
    }

    public Human SpawnHuman()
    {
        int HumanNumber = Program.Instance.Humans.Count;
        GameObject humanObject = new GameObject("Human"+HumanNumber);
        Human human = humanObject.AddComponent<Human>();
        return human;
    }

    
    public Pawn SpawnPawnForController(Vector3 pos, Controller controller)
    {
        GameObject go = GameObject.Instantiate(ProtoCapsule, pos, Quaternion.identity);
        Pawn pawn = go.AddComponent<Pawn>();
        controller.Possess(pawn);
        return pawn;
    }

    public Agent SpawnAgentWithPawn(Vector3 pos)
    {
        int AgentNumber = Boss.Instance.Agents.Count;
        GameObject agentObject = new GameObject("Agent"+AgentNumber);
        Agent agent = agentObject.AddComponent<Agent>();
        SpawnPawnForController(pos, agent);
        return agent;
    }

    public Prop SpawnProp(Vector3 pos)
    {
        GameObject go = GameObject.Instantiate(ProtoCone, pos, Quaternion.identity);
        Prop prop = go.AddComponent<Prop>();
        return prop;
    }

}
