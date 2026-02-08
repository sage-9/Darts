using System;
using UnityEngine;



public class CentreSlider: MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField]private Slider horizontalSlider;
    [SerializeField]private Slider verticalSlider;
    [SerializeField] private Transform boardCentre;
    private float _horizontalFactor;
    private float _verticalFactor;
    Vector2 _position;
    bool _verticalStarted;
    

    void Awake()
    {
        _verticalStarted = false;
        SliderManager.StartVerticalSlider+=() => _verticalStarted = !_verticalStarted;
    }
    
    void Update()
    {
        _horizontalFactor = horizontalSlider.SliderValue;
        _verticalFactor = verticalSlider.SliderValue;
        _position.x = Mathf.Lerp(horizontalSlider.lowerLimit.position.x, horizontalSlider.upperLimit.position.x, _horizontalFactor);
        _position.y = Mathf.Lerp(verticalSlider.lowerLimit.position.y, verticalSlider.upperLimit.position.y, _verticalFactor);
        MoveSlider();
    }

    void MoveSlider()
    {
        target.position = new Vector3(_position.x,boardCentre.position.y,boardCentre.position.z);
        if(_verticalStarted == false) return;
        target.position = new Vector3(_position.x,_position.y,boardCentre.position.z);
    }
    
    
}