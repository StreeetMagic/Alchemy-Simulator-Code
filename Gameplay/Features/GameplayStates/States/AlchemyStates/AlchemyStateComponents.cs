using Entitas;

namespace Code.Gameplay.Features.States.AlchemyStates
{
  [Game] public class AlchemyStateHolder : IComponent { public AlchemyStateId Value; }
  [Game] public class AlchemyStateChanger : IComponent { public AlchemyStateId Value; }
  
  [Game] public class ToAlchemyMixingStateTransitionFlag : IComponent { }
  [Game] public class FromAlchemyMixingStateTransitionFlag : IComponent { }  
  
  [Game] public class ToAlchemyIdleStateTransitionFlag : IComponent { }
  [Game] public class FromAlchemyIdleStateTransitionFlag : IComponent { }
    
  [Game] public class ToAlchemyPreparaionStateTransitionFlag : IComponent { }
  [Game] public class FromAlchemyPreparaionStateTransitionFlag : IComponent { }
    
  [Game] public class ToAlchemyFlaskShakingStateTransitionFlag : IComponent { }
  [Game] public class FromAlchemyFlaskShakingStateTransitionFlag : IComponent { }
    
  [Game] public class ToAlchemyCookingStateTransitionFlag : IComponent { }
  [Game] public class FromAlchemyCookingStateTransitionFlag : IComponent { }
}