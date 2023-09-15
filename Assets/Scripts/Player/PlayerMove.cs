using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalBound = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);
        CheckBounds();
    }

    void Move(float horizontalInput)
    {
        Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        transform.Translate(movement);
    }

    void CheckBounds()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -horizontalBound, horizontalBound);
        transform.position = currentPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Game over!");
        }

        if (other.gameObject.CompareTag("ScoreUp"))
        {
            Debug.Log("Score Up!");
        }

        if (other.gameObject.CompareTag("Tree"))
        {
            Destroy(other.gameObject);
        }
    }
}

