using UnityEngine;

public class snowball_script : MonoBehaviour
{
    public double my_size;
    private double target_size;
    private Rigidbody2D myRigidbody;
    public float power;

    [SerializeField] private TrailRenderer myTR;
    void Start()
    {
        my_size = 0.1;
        myRigidbody = GetComponent<Rigidbody2D>();
        grow();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) grow();
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(myRigidbody.mass - (float)my_size) > 0.01f)
        {
            target_size = Mathf.Lerp(myRigidbody.mass, (float)my_size, 0.1f);
            setSize();

        }
        else if (myRigidbody.mass != (float)my_size)
        {
            target_size = my_size;
            setSize();
        }
        power = myRigidbody.mass * Mathf.Abs(myRigidbody.linearVelocity.magnitude);
    }

    public void grow()
    {
        my_size += 0.05;
    }

    void setSize()
    {
        myRigidbody.mass = (float)target_size;
        this.transform.localScale = (float)target_size * new Vector3(1, 1, 1);
        myTR.widthMultiplier = (float)target_size * 0.9f;
    }
}
