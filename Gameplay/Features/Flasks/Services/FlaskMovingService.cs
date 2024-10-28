using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.Flasks.Services
{
  public class FlaskMovingService
  {
    public void Move(Transform flask, Vector3 mixPoint)
    {
      flask
        .DOMove(mixPoint, 2)
        .SetEase(Ease.InOutQuad)
        ;
    }
  }
}