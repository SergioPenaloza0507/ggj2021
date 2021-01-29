using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] float steeringSpeed;
    [SerializeField] float moveDelay;
    [SerializeField] float stopsDelay;

    Rigidbody rb;
    Vector2 cumulativeMotion;
    [SerializeField] Camera cam;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cumulativeMotion = new Vector2();
    }

    private void Update()
    {
        //if (!GameController.Instance.softPaused)
        //{
        //    ProcessMotion();
        //}
        ProcessMotion();
    }

    private void ProcessMotion()
    {
        Vector2 motion = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        cumulativeMotion += motion;
        var proj = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up) * motion.y;
        Debug.DrawLine(rb.position,rb.position + proj * 10, Color.black,0.1f);
        SteeringMotion(proj);
        ForwardMotion(proj);
    }

    private void SteeringMotion(Vector3 forward)
    {
        if (forward.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(forward, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, Time.deltaTime * steeringSpeed));
        }
    }

    private void ForwardMotion(Vector3 forward)
    {
        rb.MovePosition(rb.position + forward * Mathf.Lerp(0,1,1 - Mathf.Abs(Vector3.SignedAngle(transform.forward,forward,transform.up)) / 360) * forwardSpeed * Time.deltaTime);
    }
}
