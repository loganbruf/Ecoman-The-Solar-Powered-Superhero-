using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    
    public float speed;
    public float jumpSpeed;
    public int hearts;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    public GameObject projectile;
    public Transform projectileEmitter;

    private ProjectileBehaviour _projBehaviour;
    private BoxCollider2D _boxCollider2D;
    private int _direction = 1;
    private Vector3 _projEmitterPosRight;
    private Vector3 _projEmitterPosLeft;

    private void Start()
    {
        _projBehaviour = projectile.GetComponent<ProjectileBehaviour>();
        _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        _projEmitterPosRight = projectileEmitter.localPosition;
        _projEmitterPosLeft = new Vector3(0f-_projEmitterPosRight.x, _projEmitterPosRight.y, _projEmitterPosRight.z);
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
        
        switch(dirX)
        {
            case < 0:
                _direction = -1;
                projectileEmitter.localPosition = _projEmitterPosLeft;
                break;
            case > 0:
                _direction = 1;
                projectileEmitter.localPosition = _projEmitterPosRight;
                break;
            
        };
        
        sprite.flipX = _direction switch
        {
            < 0 => true,
            > 0 => false,
            _ => sprite.flipX
        };
        
        animator.SetBool("running", dirX is > 0 or < 0);
        
        if (Input.GetButtonDown("Fire"))
        {
            _projBehaviour.direction = _direction;
            Instantiate(projectile, projectileEmitter);
        }
        
    }

    private bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, _boxCollider2D.bounds.extents.y + extraHeight, platformLayerMask);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            GameManager.Instance.CurrHearts--;
        }
    }
}
