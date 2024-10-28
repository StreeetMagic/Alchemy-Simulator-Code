using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Common
{
  [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
  [Game] public class EntityLink : IComponent { [EntityIndex] public int Value; }
  
  [Game] public class Active : IComponent { }
  [Game] public class DurationFlag : IComponent { }
  
  [Game] public class TransformComponent : IComponent { public Transform Value; }
  [Game] public class SpriteRendererComponent : IComponent { public SpriteRenderer Value; }
  [Game] public class CharacterControllerComponent : IComponent { public CharacterController Value; }
  [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }
}