using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Video;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    
    public float speed;
    public float jumpSpeed;
    public float fireRate;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    public GameObject projectile;
    public Transform projectileEmitter;

    private AudioSource _oofSound;
    private ProjectileBehaviour _projBehaviour;
    private BoxCollider2D _boxCollider2D;
    private int _directionX = 1; //Current direction player is facing.
    
    
    
    private Vector3 _projEmitterPosRight;
    private Vector3 _projEmitterPosLeft;
    private float _dirX; //Input direction from horizontal axis.
    private float _dirY; //Input direction from vertical axis.
    private float _fireRateTimer;
    private static readonly int Movement = Animator.StringToHash("movement");

    private void Start()
    {
        _oofSound = GetComponent<AudioSource>();
        _projBehaviour = projectile.GetComponent<ProjectileBehaviour>();
        _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        _projEmitterPosRight = projectileEmitter.localPosition;
        _projEmitterPosLeft = new Vector3(0f-_projEmitterPosRight.x, _projEmitterPosRight.y, _projEmitterPosRight.z);
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _dirY = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
        
        switch(_dirX)
        {
            case < 0:
                _directionX = -1;
                projectileEmitter.localPosition = _projEmitterPosLeft;
                break;
            case > 0:
                _directionX = 1;
                projectileEmitter.localPosition = _projEmitterPosRight;
                break;
            
        }
        
        sprite.flipX = _directionX switch
        {
            < 0 => true,
            > 0 => false,
            _ => sprite.flipX
        };
        
        SetAnimation();
        
        if (Input.GetButton("Fire"))
        {
            if (_dirX == 0 && _dirY == 0)
            {
                _projBehaviour.directionX = _directionX;
            }
            else
            {
                _projBehaviour.directionX = (int)_dirX;
            }
            _projBehaviour.directionY = (int)_dirY;
            if (_fireRateTimer <= 0)
            {
                Instantiate(projectile, projectileEmitter);
                _fireRateTimer = fireRate;
            }
            else
            {
                _fireRateTimer -= Time.deltaTime;
            }
            
        }

        if (Input.GetButtonUp("Fire"))
        {
            _fireRateTimer = 0;
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_dirX * speed, rb.velocity.y);
    }

    private void SetAnimation()
    {
        if (_dirX == 0)
        {
            switch (_dirY)
            {
                case 0:
                    animator.SetInteger(Movement, 0);
                    break;
                case < 0:
                    animator.SetInteger(Movement, 1);
                    break;
                case > 0:
                    animator.SetInteger(Movement, 2);
                    break;
            }
        }
        else
        {
            switch (_dirY)
            {
                case 0:
                    animator.SetInteger(Movement, 3);
                    break;
                case < 0:
                    animator.SetInteger(Movement, 4);
                    break;
                case > 0:
                    animator.SetInteger(Movement, 5);
                    break;
                    
            }
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
        Enemy.Enemy enemy = other.gameObject.GetComponent<Enemy.Enemy>();
        if (enemy != null)
        {
            TakeDamage(1);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy.Enemy>();
        if (enemy == null) return;
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.CurrHearts -= damage;
        _oofSound.Play();
    }
    
}
