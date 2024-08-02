using System.Collections.Generic;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }  // 현재 상태
    public Dictionary<PlayerStateEnum, PlayerState> stateDictionary;

    private Player _player;

    public PlayerStateMachine()
    {
        stateDictionary = new Dictionary<PlayerStateEnum, PlayerState>();
    }

    public void Initalize(PlayerStateEnum startState, Player player)
    {
        // 초기화
        _player = player;
        CurrentState = stateDictionary[startState];
        CurrentState.Enter();  // 시작 상태 진입
    }

    public void ChangeState(PlayerStateEnum newState)
    {
        CurrentState.Exit();  // 현재 상태를 나간다
        CurrentState = stateDictionary[newState];  // 현재 상태를 Enum으로 새로운 상태로 변경
        CurrentState.Enter();  // 새로운 상태로 전환으로 진입
    }

    public void AddState(PlayerStateEnum stateEnum, PlayerState state)
    {
        stateDictionary.Add(stateEnum, state);
    }
}
