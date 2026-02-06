using System;
using UnityEngine;

public class CaptureCoordinates : MonoBehaviour
{
    [SerializeField] SliderVisuals horizontalVisuals;
    [SerializeField] SliderVisuals verticalvisuals;
    [SerializeField] private Transform target;
    Vector2 _coordinates;
    private bool _hasCapturedHorizontal;
    private bool _hasCapturedVertical;


    private void Awake()
    {
        SliderManager.PassHorizontal += () => _hasCapturedHorizontal = true;
        SliderManager.PassVertical += () => _hasCapturedVertical = true;
    }

    void Update()
    {
        _coordinates = new Vector2(horizontalVisuals.target.position.x,verticalvisuals.target.position.y);

        if (_hasCapturedHorizontal)
        {
            target.position = new Vector3(_coordinates.x,target.position.y,target.position.z);
        }

        if (_hasCapturedVertical)
        {
            target.position = new Vector3(_coordinates.x, target.position.y,target.position.z);
        }
    }
    
    
    
    
    
   
}
