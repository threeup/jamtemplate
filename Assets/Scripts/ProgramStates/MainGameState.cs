using UnityEngine;
public static class MainGameState
{
    public static void Bind(BasicState basicState)
    {
        basicState.CanEnter = CanEnter;
        basicState.OnEnter = OnEnter;
        basicState.OnExit = OnExit;
        basicState.DoUpdate = Update;
    }
    public static bool CanEnter(object owner)
    {
        Program program = (Program)owner;
        return program.Controllers.Count > 0;
    }
    public static void OnEnter(object owner)
    {
        Debug.Log("Enter MainGame");
        Factory.Instance.SpawnAgentWithPawn(new Vector3(5,5,5));
        Factory.Instance.SpawnAgentWithPawn(new Vector3(8,5,5));
        Factory.Instance.SpawnAgentWithPawn(new Vector3(2,5,5));
    }
    public static void OnExit(object owner)
    {        
    }
    public static void Update(float dt, object owner)
    {
        Program program = (Program)owner;
        if(program.Machine.timeInState > 4.0f) {
            program.Machine.Advance();
        }
    }
}