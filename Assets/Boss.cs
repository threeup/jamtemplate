using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    SPLASH,
    MENU,
    CHARACTER_SELECT,
    MAIN_GAME,
    GAME_OVER,
}

public class Boss : MonoBehaviour
{
    public List<int> Players = new List<int>();
    public StateMachine<BossState> Machine = new StateMachine<BossState>();

    // Start is called before the first frame update
    void Awake()
    {
        Machine.Initialize(this);
        SplashState.Bind(Machine[BossState.SPLASH]);
        MenuState.Bind(Machine[BossState.MENU]);
        CharacterSelectState.Bind(Machine[BossState.CHARACTER_SELECT]);
        MainGameState.Bind(Machine[BossState.MAIN_GAME]);
        GameOverState.Bind(Machine[BossState.GAME_OVER]);

        Machine.AdvanceMap[BossState.SPLASH] = BossState.MENU;
        
        Machine.AdvanceMap[BossState.MENU] = BossState.CHARACTER_SELECT;
        Machine.WithdrawMap[BossState.CHARACTER_SELECT] = BossState.MENU;

        Machine.AdvanceMap[BossState.CHARACTER_SELECT] = BossState.MAIN_GAME;
        Machine.WithdrawMap[BossState.MAIN_GAME] = BossState.CHARACTER_SELECT;

        Machine.AdvanceMap[BossState.MAIN_GAME] = BossState.GAME_OVER;
        Machine.AdvanceMap[BossState.GAME_OVER] = BossState.SPLASH;
    }
    void Start()
    {
        Machine.Begin();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Machine.MachineUpdate(dt);
    }
}
