using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    public bool pointsAwarded;

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Scored();
        }

    }

    private void Scored()
    {
        if (!pointsAwarded)
        {
            ScoreKeeper.AddToScore(gameObject.GetComponent<Rigidbody2D>().mass);
            pointsAwarded = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
