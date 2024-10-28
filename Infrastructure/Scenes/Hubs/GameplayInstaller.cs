using Code.Cooking;
using Code.Gameplay.Features.Flasks.Services;
using Code.Gameplay.Features.Items.Factory;
using Code.Gameplay.Features.Model;
using Code.Gameplay.Features.Models;
using Code.Gameplay.Features.Movement.Systems;
using Code.Gameplay.Features.States.AlchemyStates.Models;
using Code.Idle;
using Code.Infrastructure.Systems;
using Code.InteractPopups;
using Code.Mixing;
using Code.Preparation;
using Code.Shaking;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Scenes.Hubs
{
  public class GameplayInstaller : MonoInstaller
  {
    [field: SerializeField]
    private AlchemyHeadsUpDisplayView _alchemyHeadsUpDisplayView;

    [field: SerializeField]
    private WalkingHeadsUpDisplayView _walkingHeadsUpDisplayView;

    [field: SerializeField]
    private InteractPopupView _interactPopupViewView;

    [field: SerializeField]
    private AlchemyIdleHeadsUpDisplayView _alchemyIdleHeadsUpDisplayView;

    [field: SerializeField]
    private AlchemyPreparationHeadsUpDisplayView _alchemyPreparationHeadsUpDisplayView;

    [field: SerializeField]
    private AlchemyShakingHeadsUpDisplayView _alchemyShakingHeadsUpDisplayPresenter;

    [field: SerializeField]
    private AlchemyCookingHeadsUpDisplayView _alchemyCoockingHeadsUpDisplayPresenter;

    [field: SerializeField]
    private AlchemyMixingHeadsUpDisplayView _alchemyMixingHeadsUpDisplayPresenter;

    public override void InstallBindings()
    {
      Container.Bind<GameplayInitializer>().FromInstance(GetComponent<GameplayInitializer>()).AsSingle().NonLazy();
      Container.Bind<GameplayInstaller>().FromInstance(this).AsSingle();

      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

      Container.BindInterfacesAndSelfTo<MoveCharacterControllerSystem>().AsSingle();
      Container.BindInterfacesAndSelfTo<ItemFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<MixingFlaskInputHandler>().AsSingle();

      GameplayHeadsUpDisplay();
    }

    private void GameplayHeadsUpDisplay()
    {
      Container.BindInterfacesAndSelfTo<WalkingHeadsUpDisplayPresenter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<InteractPopupPresenter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<AlchemyHeadsUpDisplayPresenter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<AlchemyIdleHeadsUpDisplayPresenter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<AlchemyPreparationHeadsUpDisplayPresenter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<AlchemyShakingHeadsUpDisplayPresenter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<AlchemyCookingHeadsUpDisplayPresenter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<AlchemyMixingHeadsUpDisplayPresenter>().AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<WalkingHeadsUpDisplayView>().FromInstance(_walkingHeadsUpDisplayView).AsSingle();
      Container.BindInterfacesAndSelfTo<InteractPopupView>().FromInstance(_interactPopupViewView).AsSingle();
      Container.BindInterfacesAndSelfTo<AlchemyHeadsUpDisplayView>().FromInstance(_alchemyHeadsUpDisplayView).AsSingle();
      Container.BindInterfacesAndSelfTo<AlchemyIdleHeadsUpDisplayView>().FromInstance(_alchemyIdleHeadsUpDisplayView).AsSingle();
      Container.BindInterfacesAndSelfTo<AlchemyPreparationHeadsUpDisplayView>().FromInstance(_alchemyPreparationHeadsUpDisplayView).AsSingle();
      Container.BindInterfacesAndSelfTo<AlchemyShakingHeadsUpDisplayView>().FromInstance(_alchemyShakingHeadsUpDisplayPresenter).AsSingle();
      Container.BindInterfacesAndSelfTo<AlchemyCookingHeadsUpDisplayView>().FromInstance(_alchemyCoockingHeadsUpDisplayPresenter).AsSingle();
      Container.BindInterfacesAndSelfTo<AlchemyMixingHeadsUpDisplayView>().FromInstance(_alchemyMixingHeadsUpDisplayPresenter).AsSingle();

      Container.BindInterfacesAndSelfTo<CurrentRaycastDistanceModel>().AsSingle();
      Container.BindInterfacesAndSelfTo<InitialInteractDistanceModel>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameplayStateRelativeTimerModel>().AsSingle();
      Container.BindInterfacesAndSelfTo<InteractableNameModel>().AsSingle();
      Container.BindInterfacesAndSelfTo<InteractableActionNameModel>().AsSingle();
      Container.BindInterfacesAndSelfTo<SingleRaycasterTargetIdModel>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameplayStateHolderModel>().AsSingle();
      Container.BindInterfacesAndSelfTo<AlchemyStateHolderModel>().AsSingle();
    }
  }
}