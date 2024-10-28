using Code.Gameplay.Common;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Flasks.Services;
using Code.Gameplay.Features.Inputs.Service;
using Code.Gameplay.Features.Inventories;
using Code.Gameplay.Features.States.AlchemyStates.Services;
using Code.Infrastructure.AssetProviders;
using Code.Infrastructure.AudioServices;
using Code.Infrastructure.ConfigProviders;
using Code.Infrastructure.CoroutineRunners;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.Loggers;
using Code.Infrastructure.PersistentProgresses;
using Code.Infrastructure.RandomServices;
using Code.Infrastructure.SaveLoadServices;
using Code.Infrastructure.View.Factory;
using Code.Infrastructure.VisualEffects;
using Code.Infrastructure.ZenjectFactories.ProjectContext;
using DevConfigs;
using UnityEngine.Audio;
using Zenject;

namespace Code.Infrastructure.Projects
{
  public class ProjectInstaller : MonoInstaller
  {
    public AudioMixer AudioMixer;

    public override void InstallBindings()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
      Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();

      Container.BindInterfacesAndSelfTo<ProjectInitializer>().FromInstance(GetComponent<ProjectInitializer>()).AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<ProjectZenjectFactory>().AsSingle();

      Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefabResource(DevConfig.CoroutineRunner).AsSingle();

      Container.BindInterfacesAndSelfTo<EntityViewFactory>().AsSingle();

      Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();

      Container.Bind<ISaveLoadService>().To<PlayerPrefsSaveLoad>().AsSingle();

      Container.Bind<IInputService>().To<InputService>().AsSingle();
      Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
      Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();

      Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();
      Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
      Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<DebugLogger>().AsSingle();

      Container.Bind<IAssetProvider>().To<ResourceFolderAssetProvider>().AsSingle();

      Container.BindInterfacesAndSelfTo<BalanceConfigProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<DevConfigProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<ArtConfigProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<InventoryService>().AsSingle();
      Container.BindInterfacesAndSelfTo<VisualEffectProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<CursorService>().AsSingle();
      Container.BindInterfacesAndSelfTo<ProjectSettings>().AsSingle();

      Container.BindInterfacesAndSelfTo<ProjectData>().AsSingle();

      Container.Bind<AudioMixer>().FromInstance(AudioMixer).AsSingle();
      Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();

      Container.Bind<PlayerProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<StateSwitcherService>().AsSingle();
      Container.BindInterfacesAndSelfTo<FlaskMovingService>().AsSingle();
    }
  }
}