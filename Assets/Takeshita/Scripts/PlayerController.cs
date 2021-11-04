using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _jumpSpeed = 1f;

    BlockGenerator _generator;
    Rigidbody2D _rb;
    Vector3 _defaultScale;
    Vector2 _jumpForce;
    bool _isFlip;
    bool _isGrounded;

    bool _isPause = false;
    Vector3 _tempV = Vector3.zero;

    private void Awake()
    {
        _generator = GetComponent<BlockGenerator>();
        _rb = GetComponent<Rigidbody2D>();
        _defaultScale = this.transform.localScale;
        _jumpForce = new Vector2(0, _jumpSpeed);
    }

    private void OnEnable()
    {
        GameManager._OnPause += OnPause;
        GameManager._OnResume += OnResume;
    }

    private void OnDisable()
    {
        GameManager._OnPause -= OnPause;
        GameManager._OnResume -= OnResume;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isPause)
        {
            var h = Input.GetAxisRaw("Horizontal");
            var velocityY = _rb.velocity.y;
            if (_isFlip && h > 0)
            {
                this.transform.localScale = _defaultScale;
                _isFlip = !_isFlip;
            }
            else if (!_isFlip && h < 0)
            {
                this.transform.localScale = new Vector3(_defaultScale.x * -1, _defaultScale.y, _defaultScale.z);
                _isFlip = !_isFlip;
            }
            _rb.velocity = new Vector3(h * _moveSpeed, velocityY, 0);

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _rb.AddForce(_jumpForce, ForceMode2D.Impulse);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _generator.SpawnBlock(transform.position, _isFlip);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }

    public void OnPause()
    {
        _isPause = true;
        _tempV = _rb.velocity;
        _rb.velocity = Vector3.zero;
    }

    public void OnResume()
    {
        _isPause = false;
        _rb.velocity = _tempV;
    }
}
