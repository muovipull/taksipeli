using UnityEngine;

public class CarController : MonoBehaviour
{
    // Asetukset, joita voit muokata Inspectorissa
    public float motorTorque = 2500f;
    public float maxSteerAngle = 35f;
    public float brakeTorque = 3000f; // Aseta jarrutusvoima

    // Wheel Colliderit
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    private float verticalInput;
    private float horizontalInput;
    private bool brakeEngaged = false;

    void Update()
    {
        // K�sittele k�ytt�j�n sy�te
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Paina S-nappia jarruttaaksesi tai vaihtaaksesi peruutusvaihteelle
        if (Input.GetKeyDown(KeyCode.S))
        {
            brakeEngaged = !brakeEngaged;
        }
    }

    void FixedUpdate()
    {
        // Jos jarrutus on p��ll�, k�yt� jarrutusvoimaa
        if (brakeEngaged)
        {
            ApplyBrakes();
        }
        else
        {
            ApplyMotorAndSteer();
        }
    }

    private void ApplyMotorAndSteer()
    {
        // Liikkuminen
        rearLeftWheel.motorTorque = verticalInput * motorTorque;
        rearRightWheel.motorTorque = verticalInput * motorTorque;

        // K��ntyminen
        frontLeftWheel.steerAngle = horizontalInput * maxSteerAngle;
        frontRightWheel.steerAngle = horizontalInput * maxSteerAngle;

        // Poista jarruvoima, kun liikutaan eteenp�in tai taaksep�in
        rearLeftWheel.brakeTorque = 0;
        rearRightWheel.brakeTorque = 0;
    }

    private void ApplyBrakes()
    {
        // Aseta jarruvoima
        rearLeftWheel.brakeTorque = brakeTorque;
        rearRightWheel.brakeTorque = brakeTorque;

        // Jarruvoiman ollessa p��ll�, nollaa moottorin v��nt�
        rearLeftWheel.motorTorque = 0;
        rearRightWheel.motorTorque = 0;
    }
}