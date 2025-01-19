using UnityEngine;

public class camera_script : MonoBehaviour
{

    [SerializeField] private GameObject my_target;
    private Vector2 my_velocity = Vector2.zero;
    public float follow_strength;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(this.transform.position, my_target.transform.position, ref my_velocity, follow_strength);
        transform.position -= new Vector3(0, 0, 10);
    }
}
