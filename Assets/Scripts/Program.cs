using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProgramState
{
    SPLASH,
    MENU,
    CHARACTER_SELECT,
    MAIN_GAME,
    GAME_OVER,
}

public class Program : LazySingletonBehaviour<Program>
{
    public List<int> Players = new List<int>();
    public StateMachine<ProgramState> Machine = new StateMachine<ProgramState>();

    public List<Prop> Props = new List<Prop>();

    // Start is called before the first frame update
    void Awake()
    {
        Machine.Initialize(this);
        SplashState.Bind(Machine[ProgramState.SPLASH]);
        MenuState.Bind(Machine[ProgramState.MENU]);
        CharacterSelectState.Bind(Machine[ProgramState.CHARACTER_SELECT]);
        MainGameState.Bind(Machine[ProgramState.MAIN_GAME]);
        GameOverState.Bind(Machine[ProgramState.GAME_OVER]);

        Machine.AdvanceMap[ProgramState.SPLASH] = ProgramState.MENU;
        
        Machine.AdvanceMap[ProgramState.MENU] = ProgramState.CHARACTER_SELECT;
        Machine.WithdrawMap[ProgramState.CHARACTER_SELECT] = ProgramState.MENU;

        Machine.AdvanceMap[ProgramState.CHARACTER_SELECT] = ProgramState.MAIN_GAME;
        Machine.WithdrawMap[ProgramState.MAIN_GAME] = ProgramState.CHARACTER_SELECT;

        Machine.AdvanceMap[ProgramState.MAIN_GAME] = ProgramState.GAME_OVER;
        Machine.AdvanceMap[ProgramState.GAME_OVER] = ProgramState.SPLASH;
    }
    void Start()
    {
        Machine.Begin();
    }

    public void RegisterProp(Prop inProp)
    {
        Props.Add(inProp);
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Machine.MachineUpdate(dt);
    }
}
