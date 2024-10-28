using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.InteractPopups
{
  public class InteractPopupView : MonoBehaviour
  {
    [SerializeField]
    private GameObject _inputPressState;

    [SerializeField]
    private GameObject _inputHoldState;

    [SerializeField]
    private TMP_Text _labelHeaderText;

    [Header("PressState")]
    [SerializeField]
    private TMP_Text _buttonTextStatePress;

    [SerializeField]
    private TMP_Text _labelActionTextStatePress;

    [Header("HoldState")]
    [SerializeField]
    private TMP_Text _buttonTextStateHold;

    [SerializeField]
    private TMP_Text _labelActionTextStateHold;

    [SerializeField]
    private TMP_Text _holdText;

    [SerializeField]
    private Image _slider;

    [Button]
    public void Show()
    {
      if (gameObject.activeSelf == false)
        gameObject.SetActive(true);
    }

    [Button]
    public void Hide()
    {
      if (gameObject.activeSelf)
        gameObject.SetActive(false);
    }

    [Button]
    public void SetPressState(string headerText, string buttonText, string actionText)
    {
      SetHeaderText(headerText);
      _inputPressState.SetActive(true);
      _inputHoldState.SetActive(false);
      SetButtonTextStatePress(buttonText);
      SetActionTextStatePress(actionText);
    }

    [Button]
    public void SetHoldState(string headerText, string buttonText, string actionText, string holdText)
    {
      SetHeaderText(headerText);
      _inputPressState.SetActive(false);
      _inputHoldState.SetActive(true);
      SetButtonTextStateHold(buttonText);
      SetActionTextStateHold(actionText);
      SetHoldText(holdText);
    }

    [Button]
    public void SetSliderValue(float value)
    {
      _slider.fillAmount = Mathf.Clamp01(value);
    }

    private void SetHeaderText(string text)
    {
      _labelHeaderText.text = text;
    }

    private void SetButtonTextStatePress(string text)
    {
      _buttonTextStatePress.text = text;
    }

    private void SetButtonTextStateHold(string text)
    {
      _buttonTextStateHold.text = text;
    }

    private void SetActionTextStatePress(string text)
    {
      _labelActionTextStatePress.text = text;
    }

    private void SetActionTextStateHold(string text)
    {
      _labelActionTextStateHold.text = text;
    }

    private void SetHoldText(string text)
    {
      _holdText.text = text;
    }
  }
}