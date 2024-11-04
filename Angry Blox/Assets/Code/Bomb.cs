using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdImpulse = 5;
    public GameObject ExplosionPrefab;

    public void Destruct()
    {
        Destroy(gameObject);

    }
    public void Boom()
    {
        gameObject.GetComponent<PointEffector2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);

        Invoke("Destruct", .1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D p in collision.contacts)
        {
            if (p.normalImpulse >= ThresholdImpulse)
            {
                //Debug.Log("Boom " + p.normalImpulse);
                Boom();
                break;
            }
            //Debug.Log("no boom");
        }

    }

}
