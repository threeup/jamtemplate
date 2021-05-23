using UnityEngine;
public static class GameOverState
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
        return true;
    }
    public static void OnEnter(object owner)
    {
        Debug.Log("Enter Game Over");
        Program.Instance.PurgePawns();
    }
    public static void OnExit(object owner)
    {
           
    }
    public static void Update(float dt, object owner)
    {
        Program program = (Program)owner;
        if(program.Machine.timeInState > 4.0f) {
            program.PurgeControllers();
            program.PurgeProps();
        }
        if(program.Controllers.Count == 0 && program.Props.Count == 0)
        {
            program.Machine.Advance();
        }
    }
}