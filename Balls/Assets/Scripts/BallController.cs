using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public MatchController matchController;
    public string club; // "A" или "B"
    public Transform gate; // Ворота
    public float correctionDistance = 2f;
    public float correctionStrength = 0.5f;
    public Circle_Controller circleController;
    public TMP_Text a;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        a.text = club;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            matchController.OnGoalScored(club);
            circleController.speed *= -1;
        }
    }
}