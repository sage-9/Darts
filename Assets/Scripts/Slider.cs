using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Slider : MonoBehaviour
{
   [SerializeField] private float speed;
   public float sliderValue;
   private float _currentTime;
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
      sliderValue = Mathf.PingPong(_currentTime, 1);
   }

   public void StartSlider()
   {
      _isRunning = true;
   }

   public void StopSlider()
   {
      _isRunning = false;
   }
}
