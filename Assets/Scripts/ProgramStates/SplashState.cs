using UnityEngine;
public static class SplashState
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
        return program.Humans.Count == 0;
    }
    public static void OnEnter(object owner)
    {
        Debug.Log("Enter SplashSelect");
    }
    public static void OnExit(object owner)
    {
        
    }
    public static void Update(float dt, object owner)
    {
        Program program = (Program)owner;
        
        if(program.Machine.timeInState > 4.0f)
        {
            Factory.Instance.SpawnHuman();
        }
        if(program.Humans.Count > 0)
        {
            program.Machine.Advance();
        }
    }
}