using UnityEngine;

public class SliderVisuals : MonoBehaviour
{
   [SerializeField] private Transform start;
   [SerializeField] private Transform end;
   [SerializeField] private Transform target;
   private Slider _slider;
   private float _t;

   void Start()
   {
      _slider = GetComponent<Slider>();
   }

   void Update()
   {
      _t = _slider.sliderValue;
      target.position = Vector3.Lerp(start.position, end.position, _t);
   }
}
