using UnityEngine;
public static class BossActiveState
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
        Boss boss = (Boss)owner;
        return boss.Agents.Count > 0;
    }
    public static void OnEnter(object owner)
    {
        Debug.Log("Enter Inactive");
    }
    public static void OnExit(object owner)
    {
        
    }
    public static void Update(float dt, object owner)
    {
        Boss boss = (Boss)owner;
        
        if(boss.Machine.timeInState > 4.0f) {
            boss.Machine.Advance();
        }
    }
}