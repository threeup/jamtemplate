using UnityEngine;
public static class CharacterSelectState
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
        return program.Humans.Count > 0;
    }
    public static void OnEnter(object owner)
    {
        Debug.Log("Enter CharacterSelect");
    }
    public static void OnExit(object owner)
    {
        

    }
    public static void Update(float dt, object owner)
    {
        Program program = (Program)owner;
        Human human = program.Humans[0];
        if(program.Machine.timeInState > 4.0f) 
        {
            Factory.Instance.SpawnPawnForController(new Vector3(0,0,0), human);
        }
        if(human.ControlledPawn != null)
        {
            program.Machine.Advance();
        }
    }
}