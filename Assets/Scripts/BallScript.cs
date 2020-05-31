using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private float power;
    [SerializeField]
    private Vector3 localPosition;

    // Start is called before the first frame update
    void Start()
    {
        localPosition = transform.localPosition;
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReflectAfterCollision(Vector3 collisionOjbectPosition)
    {
        Vector3 direction = -(collisionOjbectPosition - transform.position);
        Rigidbody rig = GetComponent<Rigidbody>();

        rig.AddForce(new Vector3(direction.x * power, direction.y * power, 0), ForceMode.Impulse);
    }

    public void ResetBall()
    {
        if (GameController.Instance.CurrentLifes > 0)
        {
            gameObject.transform.localPosition = localPosition;
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.velocity = Vector3.zero;
            rig.AddForce(new Vector3(0, 30, 0) * power);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReflectAfterCollision(collision.transform.position);
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public Vector3 GetCurrentForce()
    {
        return gameObject.GetComponent<Rigidbody>().velocity;
    }

    public void SetCurrentPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetCurrentForce(Vector3 velocity)
    {
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
    }
}
