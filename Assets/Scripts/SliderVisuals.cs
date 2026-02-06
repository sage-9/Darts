using UnityEngine;

public class SliderVisuals : MonoBehaviour
{
   [SerializeField] public Transform target;
   private Slider _slider;
   private float _t;

   void Start()
   {
      _slider = GetComponent<Slider>();
   }

   void Update()
   {
      _t = _slider.sliderValue;
      target.position = Vector3.Lerp(_slider.lowerLimit.position, _slider.upperLimit.position, _t);
   }
}
