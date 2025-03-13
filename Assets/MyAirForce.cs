using UnityEngine;

public class MyAirForce : MonoBehaviour
{

    private Rigidbody rb;
    public float engineThrust = 50;
    public float liftForce = 0.5f;
    public float Drag = 0.03f;
    public float angularDrag = 0.03f;

    public float yawPower = 30f;
    public float pitchPower = 30f;
    public float rollPower = 20f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }  // Start 

    
    void Update()
    {
        if( Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * engineThrust);
        }

        Vector3 lift = Vector3.Project( rb.linearVelocity , transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftForce);

        rb.linearVelocity -= rb.linearVelocity * Drag;
        rb.angularVelocity -= rb.angularVelocity * angularDrag;

        float yaw = Input.GetAxis("Horizontal") * yawPower;
        rb.AddTorque(transform.up * yaw);

        float pitch = Input.GetAxis("Vertical") * pitchPower;
        rb.AddTorque(-transform.up * pitch);

        float Roll = Input.GetAxis("Roll") * rollPower;
        rb.AddTorque(-transform.up * Roll);

    }// Update is called once per frame




}// MyAirForce
