using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusEffect : MonoBehaviour
{
    public float kickForce;
    public float spinAmount;
    public float magnusStrenght = 0.5f;

    Rigidbody rb;
    bool isShoot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame && !isShoot)
        {
            rb.AddForce(Vector3.right * kickForce, ForceMode.Impulse);

            rb.AddTorque(Vector3.up * spinAmount);

            isShoot = true;
        }
    }

    void FixedUpdate()
    {
        if(!isShoot) return;

        Vector3 velocity = rb.linearVelocity;
        Vector3 spin = rb.angularVelocity;

        Vector3 magnusForce = magnusStrenght * Vector3.Cross(spin, velocity);
        rb.AddForce(magnusForce);
    }
}
