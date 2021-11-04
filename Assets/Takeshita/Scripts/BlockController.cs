using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool isLast = true;
    private Rigidbody2D _rb;
    private Vector3 tempV;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        GameManager._OnPause += OnPause;
        GameManager._OnResume += OnResume;
    }

    private void OnDisable()
    {
        GameManager._OnPause -= OnPause;
        GameManager._OnResume -= OnResume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && isLast)
        {
            this.transform.position += new Vector3(0, 1, 0);
        }
    }

    public void OnPause()
    {
        tempV = _rb.velocity;
        _rb.velocity = Vector3.zero;
    }

    public void OnResume()
    {
        _rb.velocity = tempV;
    }
}
