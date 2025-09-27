using UnityEngine;
using UnityEngine.UI;

public class PlatformMove : MonoBehaviour
{
    private SliderJoint2D slider;
    private JointMotor2D motor;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        motor = slider.motor;
    }

    void Update()
    {
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            motor.motorSpeed = Mathf.Abs(motor.motorSpeed);
            slider.motor = motor;
        }

        if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            motor.motorSpeed = -Mathf.Abs(motor.motorSpeed);
            slider.motor = motor;
        }
    }
}
