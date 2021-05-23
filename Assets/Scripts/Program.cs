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
    public List<Pawn> Pawns = new List<Pawn>();
    public List<Controller> Controllers = new List<Controller>();
    public List<Human> Humans = new List<Human>();
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
    public void Launch(string inParams)
    {
        Machine.Begin();
    }

    public void PurgePawns()
    {
        for(int i = Pawns.Count-1; i>=0; --i)
        {
            Pawns[i].Die();
        }
    }
    
    public void PurgeControllers()
    {
        for(int i = Controllers.Count-1; i>=0; --i)
        {
            Controllers[i].Die();
        }
    }
    
    public void PurgeProps()
    {
        for(int i = Props.Count-1; i>=0; --i)
        {
            Props[i].Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Machine.MachineUpdate(dt);
    }
}
