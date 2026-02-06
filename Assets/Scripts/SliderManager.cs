using System;
using System.Collections;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
   [SerializeField] private Slider horizontalSlider;
   [SerializeField] private Slider verticalSlider;
   private Vector2 _aimPoint;
   bool _isPressed;
   public static event Action PassHorizontal;
   public static event Action PassVertical;

   void Awake()
   {
      GameManager.OnGameStateChange += StartSliderSequence;
      InputHandler.OnClick += GetInput;
   }
   
   void GetInput()
   {
      _isPressed = true;
   }

   void StartSliderSequence(GameState state)
   {
      if(state == GameState.Play) StartCoroutine(SliderSequence());
   }

   IEnumerator SliderSequence()
   {
      horizontalSlider.StartSlider();
      yield return new WaitUntil(() => _isPressed);
      _isPressed = false;
      horizontalSlider.StopSlider();
      PassHorizontal?.Invoke();
      verticalSlider.StartSlider();
      yield return new WaitUntil((() => _isPressed));
      _isPressed = false;
      verticalSlider.StopSlider();
      PassVertical?.Invoke();
   }
}
