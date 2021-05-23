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
        return program.Players.Count > 0;
    }
    public static void OnEnter(object owner)
    {
        Debug.Log("Enter MainGame");
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