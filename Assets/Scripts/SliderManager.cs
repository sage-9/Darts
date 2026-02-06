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

  
   void Awake()
   {
      GameManager.StartSliderSequence += StartSliderSequence;
      InputHandler.OnClick += GetInput;
      GameManager.CalculateScore += (() => CalculateScore?.Invoke(_aimPoint));
   }
   
   void GetInput()
   {
      _isPressed = true;
   }

   void CalculateHitPosition()
   {
      _aimPoint.x = Mathf.Lerp(horizontalSlider.lowerLimit.position.x, horizontalSlider.upperLimit.position.x, horizontalSlider.sliderValue);
      _aimPoint.y = Mathf.Lerp(verticalSlider.lowerLimit.position.y, verticalSlider.upperLimit.position.y, verticalSlider.sliderValue);
         
   }
   
   void StartSliderSequence()
   {
      StartCoroutine(SliderSequence());
   }

   IEnumerator SliderSequence()
   {
      horizontalSlider.StartSlider();
      yield return new WaitUntil(() => _isPressed);
      _isPressed = false;
      horizontalSlider.StopSlider();
      verticalSlider.StartSlider();
      yield return new WaitUntil((() => _isPressed));
      _isPressed = false;
      verticalSlider.StopSlider();
      CalculateHitPosition();
      SequenceFinished?.Invoke();
   }
}
