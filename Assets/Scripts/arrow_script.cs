using UnityEngine;

public class arrow_script : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject kicker;
    public float transparency;
    private SpriteRenderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        transparency = 0.5f;
    }

    void Update()
    {
        if (kicker.GetComponent<kick_script>().can_kick || (Vector2.Distance(target.transform.position, this.transform.position) >= 8))
        {
            transparency = 0.5f;
        }
        else
        {
            transparency = 0;
        }

        transform.right = target.transform.position - transform.position;
        Color myColor = Color.white;
        myColor.a = transparency;
        myRenderer.color = myColor;
    }
}
