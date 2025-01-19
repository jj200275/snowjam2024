using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class kick_script : MonoBehaviour
{
    private Collider2D myCollider;
    public bool can_kick;
    [SerializeField] private Rigidbody2D snowball;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        can_kick = false;
    }

    void Update()
    {
        if (can_kick && Input.GetKeyDown(KeyCode.Space))
        {
            snowball.AddForce(10 * (snowball.transform.position - transform.position), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        can_kick = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        can_kick = false;
    }
}
