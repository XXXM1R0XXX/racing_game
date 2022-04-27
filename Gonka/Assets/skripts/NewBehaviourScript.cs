/*using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public float fuel = 100;
    private float _t = 0;
    public UnityEngine.UI.Image Image;
    public KeyCode move = KeyCode.D;// движение вперед
    public KeyCode smoothStop = KeyCode.A; // плавное торможение
    public KeyCode stop = KeyCode.Space; // быстрое торможение
    public float moveSpeed = 250; // макс скорость
    public bool invert = true; // инвертировать направление
    public float smoothStep = 1; // плавное ускорение/торможение
    public float stopStep = 10; // шаг для быстрого торможения
    public float freeStep = 0.05f; // постепенное падение скорости, когда клавиша движения не нажата
    [HideInInspector] public float velocity; // текущая скорость тела по Х
    private JointMotor2D jointMotor;
    private WheelJoint2D[] wheel;
    private Rigidbody2D body;
    private int inv;
    private float curSpeed, curSmooth;
    public UnityEngine.UI.Image image;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        wheel = GetComponents<WheelJoint2D>();
        jointMotor.maxMotorTorque = 10000;
        jointMotor.motorSpeed = 0;
        foreach (WheelJoint2D w in wheel)
        {
            w.useMotor = true;
            w.motor = jointMotor;
        }
    }

    float Round(float value, float to) // округлить до указанного значения
    {
        return ((int)(value * to)) / to;
    }

    void MovementControl()
    {
        if (Input.GetKey(move))
        {
            curSpeed = moveSpeed * inv;
            curSmooth = smoothStep;
        }
        else if (Input.GetKey(smoothStop))
        {
            curSpeed = 0;
            curSmooth = smoothStep;
        }
        else if (Input.GetKey(stop))
        {
            curSpeed = 0;
            curSmooth = stopStep;
        }
        else
        {
            curSpeed = 0;
            curSmooth = freeStep;
        }
    }

    void Update()
    {
        if (_t < Time.time)
        {
            _t = Time.time + 1;
            fuel=fuel-3;
        }
        Image.fillAmount = fuel/100;
        velocity = Round(body.velocity.x, 100f); // округляем до сотых
        if (invert) inv = -1; else if (!invert) inv = 1;

        MovementControl();
        AdjustSpeed();
    }

    void AdjustSpeed()
    {
        jointMotor.motorSpeed = Mathf.Lerp(jointMotor.motorSpeed, curSpeed, curSmooth * Time.deltaTime);
        foreach (WheelJoint2D w in wheel)
        {
            w.motor = jointMotor;
        }
    }
}
using UnityEngine;
using System.Collections;
public class NewBehaviourScript : MonoBehaviour
{
    public WheelJoint2D[] wheels;
    void Start()
    {
        wheels = gameObject.GetComponents<WheelJoint2D>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") < -0.8 || Input.GetAxis("Horizontal") > 0.8)
        {
            foreach (WheelJoint2D joint in wheels)
            {
                var motor = joint.motor;
                motor.motorSpeed = 1000 * Input.GetAxis("Horizontal") * -1;
                joint.motor = motor;
                joint.useMotor = true;
            }
        }
        else
        {
            foreach (WheelJoint2D joint in wheels)
            {
                var motor = joint.motor;
                motor.motorSpeed = 0;
                joint.motor = motor;
                joint.useMotor = false;
            }
        }

    }
    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("ObjX", gameObject.transform.position.x);
        PlayerPrefs.SetFloat("ObjY", gameObject.transform.position.y);
    }
}*/
using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public float fuel = 1;
    public float fuelconsumption = 0.1f;
    public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float speed = 100;
    public float carTorque = 50;
    private float movement;
    public UnityEngine.UI.Image image;

    void Start()
    {
        
    }
    void Update()
    {

        movement = Input.GetAxis("Horizontal");
        image.fillAmount = fuel;
    }
    private void FixedUpdate()
    {
        if (fuel > 0)
        {
            backTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            carRigidbody.AddTorque(-movement * speed * Time.fixedDeltaTime);
        }
        fuel -= fuelconsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
    }
}