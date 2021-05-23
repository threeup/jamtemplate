using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Camera mainCamera;
    private Program program;
    private Boss boss;
    private Factory factory;
    
    // Start is called before the first frame update
    void Start()
    {
        program = Program.Instance;
        boss = Boss.Instance;
        factory = Factory.Instance;
        mainCamera = Camera.main;
        mainCamera.transform.position = new Vector3(4,0,10);
        factory.SpawnAgent(new Vector3(5,5,5));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
