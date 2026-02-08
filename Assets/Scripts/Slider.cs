using UnityEngine;


public class Slider : MonoBehaviour
{
   private float _speed;
   public float SliderValue { get; private set; }
   public Transform lowerLimit;
   public Transform upperLimit;
   private float _currentTime = 0.5f;
   bool _isRunning;

   void Start()
   {
      SetSpeed();
   }

   
   void Update()
   {
      if (_isRunning)
      {
         RunSlider();
      }
      
   }
   void RunSlider()
   {
      _currentTime += Time.deltaTime * _speed;
      SliderValue = Mathf.PingPong(_currentTime, 1);
     
   }

   public void StartSlider()
   {
      _isRunning = true;
      _currentTime = 0.5f;
   }

   public void StopSlider()
   {
      _isRunning = false;
   }

   public void ResetSlider()
   {
      _currentTime = 0.5f;
      SliderValue = 0;
   }
   
   void SetSpeed()
   {
      switch (GameManager.Instance.difficulty)
      {
         case Difficulty.Easy:
         {
            _speed = 0.5f;
            break;
         }
         case Difficulty.Medium:
         {
            _speed = 1.0f;
            break;
         }
         case Difficulty.Hard:
         {
            _speed = 1.5f;
            break;
         }
      }
   }
}
