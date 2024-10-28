using System.Collections.Generic;
using Code.Common.Enums;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Flasks.Services
{
  public class MixingFlaskInputHandler : IInitializable
  {
    private static readonly Dictionary<DirectionId, ClockWiseDirectionId> s_quarter1 = new()
    {
      { DirectionId.SouthEast, ClockWiseDirectionId.Clockwise },
      { DirectionId.NorthWest, ClockWiseDirectionId.CounterClockwise },

      { DirectionId.SouthWest, ClockWiseDirectionId.Unknown },
      { DirectionId.NorthEast, ClockWiseDirectionId.Unknown },
    };

    private static readonly Dictionary<DirectionId, ClockWiseDirectionId> s_quarter2 = new()
    {
      { DirectionId.NorthEast, ClockWiseDirectionId.Clockwise },
      { DirectionId.SouthWest, ClockWiseDirectionId.CounterClockwise },

      { DirectionId.NorthWest, ClockWiseDirectionId.Unknown },
      { DirectionId.SouthEast, ClockWiseDirectionId.Unknown },
    };

    private static readonly Dictionary<DirectionId, ClockWiseDirectionId> s_quarter3 = new()
    {
      { DirectionId.NorthWest, ClockWiseDirectionId.Clockwise },
      { DirectionId.SouthEast, ClockWiseDirectionId.CounterClockwise },

      { DirectionId.NorthEast, ClockWiseDirectionId.Unknown },
      { DirectionId.SouthWest, ClockWiseDirectionId.Unknown },
    };

    private static readonly Dictionary<DirectionId, ClockWiseDirectionId> s_quarter4 = new()
    {
      { DirectionId.SouthWest, ClockWiseDirectionId.Clockwise },
      { DirectionId.NorthEast, ClockWiseDirectionId.CounterClockwise },

      { DirectionId.SouthEast, ClockWiseDirectionId.Unknown },
      { DirectionId.NorthWest, ClockWiseDirectionId.Unknown },
    };

    private static readonly Dictionary<EuclidGeometryQuarterId, Dictionary<DirectionId, ClockWiseDirectionId>> s_euclidGeometry = new()
    {
      { EuclidGeometryQuarterId.I, s_quarter1 },
      { EuclidGeometryQuarterId.II, s_quarter2 },
      { EuclidGeometryQuarterId.III, s_quarter3 },
      { EuclidGeometryQuarterId.IV, s_quarter4 },
    };

    private Vector3 _lastMousePosition;
    private Vector3 _crossCenter;

    public void Initialize()
    {
      _crossCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
    }

    public bool GetClockWise(out ClockWiseDirectionId clockwiseDirection, out float length)
    {
      clockwiseDirection = ClockWiseDirectionId.Unknown;
      length = 0;

      if (!Input.GetMouseButton(0))
        return false;

      Vector3 currentMousePosition = Input.mousePosition;

      DirectionId directionId = GetDirection(currentMousePosition - _lastMousePosition);

      length = Vector3.Distance(_lastMousePosition, currentMousePosition);

      _lastMousePosition = currentMousePosition;

      switch (directionId)
      {
        case DirectionId.NorthEast:
        case DirectionId.SouthWest:
        case DirectionId.SouthEast:
        case DirectionId.NorthWest:

          EuclidGeometryQuarterId quarter = GetQuarter(currentMousePosition);

          if (quarter != EuclidGeometryQuarterId.Unknown)
          {
            clockwiseDirection = s_euclidGeometry[quarter][directionId];

            if (clockwiseDirection != ClockWiseDirectionId.Unknown)
            {
              return true;
            }
          }

          break;

        case DirectionId.North:
        case DirectionId.East:
        case DirectionId.South:
        case DirectionId.West:
          break;

        default:
        case DirectionId.Unknown:
          break;
      }

      return false;
    }

    private DirectionId GetDirection(Vector3 delta)
    {
      if (delta == Vector3.zero)
        return DirectionId.Unknown;

      float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

      if (angle < 0)
        angle += 360;

      if (angle >= 337.5 || angle < 22.5)
        return DirectionId.East;
      else if (angle >= 22.5 && angle < 67.5)
        return DirectionId.NorthEast;
      else if (angle >= 67.5 && angle < 112.5)
        return DirectionId.North;
      else if (angle >= 112.5 && angle < 157.5)
        return DirectionId.NorthWest;
      else if (angle >= 157.5 && angle < 202.5)
        return DirectionId.West;
      else if (angle >= 202.5 && angle < 247.5)
        return DirectionId.SouthWest;
      else if (angle >= 247.5 && angle < 292.5)
        return DirectionId.South;
      else if (angle >= 292.5 && angle < 337.5)
        return DirectionId.SouthEast;

      return DirectionId.Unknown;
    }

    private EuclidGeometryQuarterId GetQuarter(Vector3 currentMousePosition)
    {
      float axisWidth = 3f;

      float crossX = _crossCenter.x;
      float crossY = _crossCenter.y;

      float posX = currentMousePosition.x;
      float posY = currentMousePosition.y;

      if (Mathf.Abs(crossX - posX) < axisWidth || Mathf.Abs(crossY - posY) < axisWidth)
        return EuclidGeometryQuarterId.Unknown;

      if (crossX > posX && crossY > posY)
        return EuclidGeometryQuarterId.III;

      if (crossX < posX && crossY > posY)
        return EuclidGeometryQuarterId.IV;

      if (crossX < posX && crossY < posY)
        return EuclidGeometryQuarterId.I;

      return EuclidGeometryQuarterId.II;
    }
  }
}