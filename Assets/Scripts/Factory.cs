using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : LazySingletonBehaviour<Factory>
{
    public GameObject ProtoCube;
    public GameObject ProtoCapsule;
    public GameObject ProtoCone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject SpawnCube(Vector3 pos)
    {
        GameObject go = GameObject.Instantiate(ProtoCube, pos, Quaternion.identity);
        return go;
    }

    public Agent SpawnAgent(Vector3 pos)
    {
        GameObject go = GameObject.Instantiate(ProtoCapsule, pos, Quaternion.identity);
        Agent agent = go.AddComponent<Agent>();
        return agent;
    }

    public Prop SpawnProp(Vector3 pos)
    {
        GameObject go = GameObject.Instantiate(ProtoCone, pos, Quaternion.identity);
        Prop prop = go.AddComponent<Prop>();
        return prop;
    }

}
