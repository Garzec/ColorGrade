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
        ToggleGravity(true);
    }

    public void Reset(Color color)
    {
        ToggleGravity(false);
        SetPosition();
        ChangeColor(color);
    }

    private void SetPosition()
    {
        transform.position = initialPosition;
    }

    private void ToggleGravity(bool isActive)
    {
        rigid.isKinematic = !isActive;
    }

    private void ChangeColor(Color color)
    {
        rend.color = color;
    }
}