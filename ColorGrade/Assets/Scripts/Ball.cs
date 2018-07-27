using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private SpriteRenderer rend;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void Drop()
    {
        ToggleRigidbody(true);
    }

    public void Reset(Color color)
    {
        ToggleRigidbody(false);
        SetPosition();
        ChangeColor(color);
    }

    private void SetPosition()
    {
        transform.position = initialPosition;
    }

    private void ToggleRigidbody(bool isActive)
    {
        rigid.isKinematic = !isActive;
        if (rigid.isKinematic)
        {
            rigid.velocity = Vector2.zero;
        }
    }

    private void ChangeColor(Color color)
    {
        rend.color = color;
    }
}