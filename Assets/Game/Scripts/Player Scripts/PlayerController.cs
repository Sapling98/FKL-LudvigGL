using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private bool isAlive = true;

    [Header("Movement Settings")]
    public float speed;
    public float jumpForce;
    public float groundDist;
    public float rayCastJump;
    public float groundCheckRadius;

    [Header("Animation")]
    public LayerMask terrainLayer;
    public Rigidbody _rb;
    public SpriteRenderer _sr;
    public Animator _anim;
    [SerializeField] private string currentAnimation;

    const string Run = "Run";
    const string Idle = "Idle";
    const string JumpDOWN = "JumpDOWN";
    const string JumpTOP = "JumpTOP";
    const string JumpUP = "JumpUP";

    [Header("UI")]
    public GameObject gameOverUI;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isAlive)
        {

            Vector3 castPos = transform.position * Time.deltaTime;
            castPos.y += 1;

            float _x = Input.GetAxisRaw("Horizontal");
            float _y = Input.GetAxisRaw("Vertical");
            Vector3 moveDir = new Vector3(_x, 0, _y);
            _rb.velocity = new Vector3(moveDir.x * speed, _rb.velocity.y, moveDir.z * speed);

            if (_x != 0 && _x < 0)
            {
                _sr.flipX = true;
            }
            else if (_x != 0 && _x > 0)
            {
                _sr.flipX = false;
            }

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("Jump");
            }

            if (!IsGrounded())
            {
                if (_rb.velocity.y <= 3 && _rb.velocity.y >= -3)
                {
                    ChangeAnimationState(JumpTOP);
                }
                else if (_rb.velocity.y > 3)
                {
                    ChangeAnimationState(JumpUP);
                }
                else if (_rb.velocity.y < -3)
                {
                    ChangeAnimationState(JumpDOWN);
                }
            }
            else

            if (_rb.velocity.x != 0 || _rb.velocity.z != 0)
            {
                ChangeAnimationState(Run);
            }
            else
            {
                ChangeAnimationState(Idle);
            }
        }
        else
        {
           Time.timeScale = 0f;
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float raycastLength = rayCastJump;
        return Physics.Raycast(transform.position, -transform.up, out hit, raycastLength, terrainLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentAnimation == newState) return;
        _anim.Play(newState);
        currentAnimation = newState;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            Debug.Log("Death");
            gameOverUI.SetActive(true);
            isAlive = false;
        }
    }
}
