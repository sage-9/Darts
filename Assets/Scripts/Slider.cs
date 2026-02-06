using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Slider : MonoBehaviour
{
  
   public Transform lowerLimit;
   public Transform upperLimit;
   [SerializeField] private float speed;
   [HideInInspector]public float sliderValue;
   
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
