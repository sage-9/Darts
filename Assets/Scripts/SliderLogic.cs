using UnityEngine;

public class SliderLogic : MonoBehaviour
{
    [SerializeField] bool timerIsPaused;
    [SerializeField] float speed;
    public float CurrentValue {get;private set; }
    
    private float _currentTime;
   
    
    
    
    //start the manual timer
    //get the ping pong Lerp value(t)
    //pass the necessary information to the UI handler

    void Start()
    {
        timerIsPaused = false;
    }

    void Update()
    {
        if (!timerIsPaused)
        {
            RunTimer();
        }
        CurrentValue = Mathf.PingPong(_currentTime, 1);
    }

    void RunTimer()
    {
        _currentTime+= Time.deltaTime * speed;
    }

    
   
}
