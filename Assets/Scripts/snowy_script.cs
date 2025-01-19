using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class snowy_script : MonoBehaviour
{
    private GameObject target;
    private GameObject snowball;
    [SerializeField] private Rigidbody2D myRigidBody;
    public float targetAngle;
    private float timer;
    private int health;

    public float velocity;

    void Start()
    {
        timer = 0;
        health = 5;
        if (target == null)
        {
            target = GameObject.Find("Player");
        }
        if (snowball == null)
        {
            snowball = GameObject.Find("Snowball");
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            targetAngle = Mathf.Atan2((target.transform.position.y - this.transform.position.y), (target.transform.position.x - this.transform.position.x));
            targetAngle += (Random.value * 80 - 40) * Mathf.PI/180;
            timer = 0.6f;

            Vector2 targetVelocity = velocity * new Vector2(Mathf.Cos(targetAngle), Mathf.Sin(targetAngle));
            myRigidBody.AddForce(targetVelocity, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            if(snowball.GetComponent<snowball_script>().power >= 2)
            {
                health -= (int)snowball.GetComponent<snowball_script>().power;
                if(health <= 0)
                {
                    snowball.GetComponent<snowball_script>().grow();
                    Debug.Log("Snowy died");
                }
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Snowy hit the player");
        }
    }
}
