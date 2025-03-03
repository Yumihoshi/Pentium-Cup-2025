using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public float factor = 0.5f;
    public float speed = 1.15f;
    private bool GO;
    private float initial_size_x;
    private float initial_size_y;

    private void Awake()
    {
        initial_size_x = transform.localScale.x;
        initial_size_y = transform.localScale.y;
    }

    private void FixedUpdate()
    {
        if (GO)
        {
            float aux_x = transform.localScale.x;
            float aux_y = transform.localScale.y;
            if (transform.localScale.y < initial_size_y)
            {
                aux_x *= speed;
                aux_y *= speed;
                transform.localScale = new Vector3(aux_x, aux_y, 1.0f);
            }
            else
            {
                aux_x = initial_size_x;
                aux_y = initial_size_y;
                transform.localScale = new Vector3(aux_x, aux_y, 1.0f);
                GO = false;
            }
        }
    }

    private void Go()
    {
        GO = true;
        transform.localScale = new Vector3(initial_size_x * factor,
            initial_size_y * factor, 1.0f);
    }
}
