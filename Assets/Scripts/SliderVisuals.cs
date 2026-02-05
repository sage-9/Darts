using UnityEngine;

public class SliderVisuals : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] private Transform target;
    private SliderLogic _sliderLogic;
    private float _t;

    void Start()
    {
        _sliderLogic = GetComponent<SliderLogic>();
        
    }

    void Update()
    {
        _t = _sliderLogic.CurrentValue;
        target.position = Vector3.Lerp(start.position, end.position, _t);
    }
}
