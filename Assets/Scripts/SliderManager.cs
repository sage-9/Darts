using System;
using System.Collections;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
   [SerializeField] private Slider horizontalSlider;
   [SerializeField] private Slider verticalSlider;

   
   private Vector2 _aimPoint;
   bool _isPressed;
   
   public static event Action SequenceFinished;
   public static event Action<Vector2> CalculateScore;
   public static event Action StartVerticalSlider;

  
   void Awake()
   {
      GameManager.StartSliderSequence += StartSliderSequence;
      InputHandler.OnClick += (() => _isPressed = true);
      InputHandler.OnClick += StopAndGetValue;
      GameManager.CalculateScore += (() => CalculateScore?.Invoke(_aimPoint));
      
   }

   void StartSliderSequence()
   {
      StartCoroutine(SliderSequence());
   }
   
   void CalculateHitPosition()
   {
      _aimPoint.x = Mathf.Lerp(horizontalSlider.lowerLimit.position.x, horizontalSlider.upperLimit.position.x, horizontalSlider.SliderValue);
      _aimPoint.y = Mathf.Lerp(verticalSlider.lowerLimit.position.y, verticalSlider.upperLimit.position.y, verticalSlider.SliderValue);
   }
   
   void StopAndGetValue()
   {
      horizontalSlider.StopSlider();
      verticalSlider.StopSlider();
   }
   
   IEnumerator SliderSequence()
   {
     horizontalSlider.StartSlider();
      yield return new WaitUntil(() => _isPressed);
      _isPressed = false;
      StartVerticalSlider?.Invoke();
      verticalSlider.StartSlider();
      yield return new WaitUntil((() => _isPressed));
      _isPressed = false;
      StartVerticalSlider?.Invoke();
      CalculateHitPosition();
      horizontalSlider.ResetSlider();
      verticalSlider.ResetSlider();
      SequenceFinished?.Invoke();
   }

   private void OnDisable()
   {
      InputHandler.OnClick -= StopAndGetValue;
      GameManager.StartSliderSequence -= StartSliderSequence;
   }
}
