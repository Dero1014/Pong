using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed;
    public float AngleModifier;

    [Range(-1,1)]
    public float x;
    [Range(-1, 1)]
    public float y;

    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    // pick random direction
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float x = Random.value > 0.5f ? -1 : 1;
        float y = Random.value > 0.5f ? Random.Range(-1, -0.5f) : Random.Range(0.5f, 1);

        direction = new Vector2(x, y).normalized;
        print(direction);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Vector2 localScale = collision.transform.localScale;
            bool tallOnX = localScale.x > localScale.y;
            if (tallOnX){
                Vector2 reflected = Vector2.Reflect(direction, collision.transform.up);

                direction = reflected;
            }
            else
            {
                
                float distance = transform.position.y - collision.transform.position.y;
                float maxDistance = 0.85f;
                print(distance);
                float angleDispersion = AngleModifier * Mathf.Clamp((distance / maxDistance), 0f, 1f) * Mathf.Deg2Rad;
                Vector2 reflectedSurface = new Vector2(Mathf.Cos(angleDispersion), Mathf.Sin(angleDispersion));
                Vector2 reflected = Vector2.Reflect(direction, -reflectedSurface);

                print(angleDispersion);
                print(reflectedSurface);

                direction = reflected;
            }

            if (collision.gameObject.name.Contains("Right"))
            {
                Scoring.instance.PlayerScored();
                transform.position = Vector2.zero;
            }
            if (collision.gameObject.name.Contains("Left"))
            {
                Scoring.instance.ComputerScored();
                transform.position = Vector2.zero;
            }
            direction = direction.normalized;
        }
    }
}
