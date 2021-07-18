using System.Linq;
using Zenject;
using GameSateMachine;
using NaughtyAttributes;


public class GameInstaller : MonoInstaller
{
    [Foldout("For developers only!")] public GameState[] States;
    private GameState _gameplay;
    public override void InstallBindings()
    {
        Container.Bind<StateMachine>().FromNew().AsSingle().NonLazy();
        Container.BindInstance(States).WhenInjectedInto<GameEntryPoint>();
        Container.Bind<PlayerStats>().FromNew().AsSingle().NonLazy();
        foreach (var state in States)
        {
            if (state.Type == TypeStates.Gameplay) _gameplay = state;
        }
        Container.BindInstance(_gameplay).WhenInjectedInto<DeathZone>();
        Container.BindInstance(_gameplay).WhenInjectedInto<DisplayStats>();
    }
}