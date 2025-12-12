using UnityEngine;


public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private float _moveSpeed = 10;


    private void Awake()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        this._rigidbody2D.velocity = this._rigidbody2D.velocity.normalized * this._moveSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Ball"))
        {
            return;
        }
    }

}   // class Ball