using NaughtyAttributes;
using Gameplay;
using UnityEngine;
using Zenject;

namespace Installers
{
    internal sealed class LevelInstaller : MonoInstaller
    {
        [Foldout("For developers only!")] public Ball PlayerBall;
        [Foldout("For developers only!")] public Camera GameplayCamera;
        [Foldout("For developers only!")] public Rigidbody BallRigidbody;
        [Foldout("For developers only!")] public Chunk[] Prefabs;
    
        public override void InstallBindings()
        {
            Container.Bind<LevelCreator>().FromNew().AsSingle().WhenInjectedInto<Level>();
            Container.Bind<CameraBounds>().FromNew().AsSingle().WhenInjectedInto<Level>();
            Container.Bind<ObjectPool>().FromNew().AsSingle().WhenInjectedInto<ILevelCreator>();
            Container.Bind<LevelMovement>().FromNew().AsSingle().WhenInjectedInto<Level>();
            Container.BindInstance(Prefabs).WhenInjectedInto<ILevelCreator>();

            Container.Bind<BallColision>().FromNew().AsSingle().WhenInjectedInto<Ball>().NonLazy();
            Container.BindInstance(GameplayCamera).WhenInjectedInto<CameraBounds>();
            Container.Bind<CustomGravity>().FromNew().AsSingle().WhenInjectedInto<Ball>().NonLazy();
            Container.BindInstance(BallRigidbody).WhenInjectedInto<Ball>();
        }
    }
}