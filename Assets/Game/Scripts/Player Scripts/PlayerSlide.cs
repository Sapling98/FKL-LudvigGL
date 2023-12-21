using System.Collections;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public bool isSliding = false;

    public PlayerController _pc;
    public Rigidbody _rb;
    public Animator _anim;

    public CapsuleCollider regularColl;
    public CapsuleCollider slideColl;

    const string Slide = "Slide";
    [SerializeField] private string currentAnimation;

    public float slideSpeed;
    //public float _x;

    private void Start()
    {
        _pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && !isSliding)
        {
            PerformSlide();
        }


    }
        
    private void PerformSlide()
    {
        isSliding = true;

        ChangeAnimationState("Run");

        ChangeAnimationState("Slide");

        regularColl.enabled = false;
        slideColl.enabled = true;

        float _x = Input.GetAxisRaw("Horizontal");
        Vector3 moveDir;

        if (_x < 0)
        {
            moveDir = new Vector3(_x, 0, 0);
        }
        else
        {
            moveDir = new Vector3(-_x, 0, 0);
        }

        StartCoroutine("StopSlide");
    }


    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(1.3f);
        _anim.Play("Run");
        regularColl.enabled = true;
        slideColl.enabled = false;
        isSliding = false;
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentAnimation == newState) return;
        _anim.Play(newState);
        currentAnimation = newState;
    }
}
