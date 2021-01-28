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
        Vector3 projectedForward = (transform.position + Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up)).normalized * motion.y;
        Quaternion rotator = Quaternion.Euler(0, cumulativeMotion.x, 0);
        projectedForward = rotator * projectedForward;
        Debug.DrawLine(transform.position, transform.position + projectedForward,Color.black,0.1f);
        SteeringMotion(projectedForward);
        ForwardMotion(projectedForward);
    }

    private void SteeringMotion(Vector3 forward)
    {
        if (forward.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(rb.position + forward, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, Time.deltaTime * steeringSpeed));
        }
    }

    private void ForwardMotion(Vector3 forward)
    {
        rb.MovePosition(rb.position + Mathf.Lerp(0, 1, 1 - (Mathf.Abs(Vector3.SignedAngle(transform.forward, forward, Vector3.up)) / 360)) * forward * forwardSpeed * Time.deltaTime);
    }
}
