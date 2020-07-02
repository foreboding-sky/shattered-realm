public interface IState
{
    void StateUpdate();
    void OnEnter();
    void OnExit();
}