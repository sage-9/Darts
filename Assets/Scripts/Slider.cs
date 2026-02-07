using UnityEngine;


public class Slider : MonoBehaviour
{
   [SerializeField] private float speed;
   public float SliderValue { get; private set; }
   public Transform lowerLimit;
   public Transform upperLimit;
   private float _currentTime = 0.5f;
   bool _isRunning;

   void Update()
   {
      if (_isRunning)
      {
         RunSlider();
      }
      
   }
   void RunSlider()
   {
      _currentTime += Time.deltaTime * speed;
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
}
