using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [Foldout("For developers only!")] public Ball PlayerBall;
    [Foldout("For developers only!")] public Camera GameplayCamera;
    [Foldout("For developers only!")] public Animator BallAnimator;
    [Foldout("For developers only!")] public Rigidbody BallRigidbody;
    
    public override void InstallBindings()
    {
        Container.Bind<LevelCreator>().FromNew().AsSingle().WhenInjectedInto<Level>();
        Container.Bind<LevelMovement>().FromNew().AsSingle().WhenInjectedInto<Level>();
        Container.Bind<CameraBounds>().FromNew().AsSingle().WhenInjectedInto<Level>();
        Container.Bind<ObjectPool>().FromNew().AsSingle().WhenInjectedInto<Level>();

        Container.Bind<BallColision>().FromNew().AsSingle().WhenInjectedInto<Ball>().NonLazy();
        Container.BindInstance(BallAnimator).WhenInjectedInto<Ball>();
        Container.BindInstance(PlayerBall).WhenInjectedInto<PlayerInput>();
        Container.BindInstance(GameplayCamera).WhenInjectedInto<CameraBounds>();
        Container.Bind<CustomGravity>().FromNew().AsSingle().WhenInjectedInto<Ball>().NonLazy();
        Container.BindInstance(BallRigidbody).WhenInjectedInto<Ball>();
    }
}