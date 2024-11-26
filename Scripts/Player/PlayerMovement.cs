using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public event Action<Vector2> MovementEvent;

    // Input
    [SerializeField] public InputReader _inputReader;

    private PlayerHealth _playerHealth;

    [Header("Movement Setting Value")]
    [SerializeField] private float _moveSpeed = 7f, _jumpPower = 10f, _chargeAttackMovePower = 12f;
    private float _originalMoveSpeed = 0;

    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;

    private bool _isChargeAttack = false;
    public bool isDown = false;
    public bool isFall = false;

    [Header("Ray Setting Value")]
    [SerializeField] private float _rayDistance = 1.2f;
    [SerializeField] private LayerMask _whatIsGround;
    private Collider2D[] _colliders;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _maxDistance;

    public bool IsGround { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsMaxCharge { get; private set; }

    private void InitComponent()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void InitEvent()
    {
        _inputReader.OnJumpEvent += JumpHandle;
        _inputReader.OnAttackEvent += AttackHandle;
        _inputReader.OnMaxChargeEvent += HandleMaxChargeEvent;
    }

    void OnDisable()
    {
        _inputReader.OnJumpEvent -= JumpHandle;
        _inputReader.OnAttackEvent -= AttackHandle;
        _inputReader.OnMaxChargeEvent -= HandleMaxChargeEvent;
    }

    private void Initializer()
    {
        _inputReader._playerActions.Player.Enable();
        _originalMoveSpeed = _moveSpeed;
        InitComponent();
        InitEvent();
    }

    private void Awake()
    {
        Initializer();
    }

    void Start()
    {
        _playerHealth = PlayerManager.Instance.Player.PlayerHealthCompo;
    }

    void Update()
    {
        CheckDown();
        CheckGround();
        CheckJump();
        CheckFall();
    }

    private void FixedUpdate()
    {
        Movement();
        ChargeAttackRay();
    }

    private void Movement()
    {
        if (_isChargeAttack) return;

        Vector2 _velocity = _inputReader._playerActions.Player.Movement.ReadValue<Vector2>();
        MovementEvent?.Invoke(_velocity);

        _velocity = new Vector2(_velocity.x * _moveSpeed, _rigidbody.velocity.y);

        _rigidbody.velocity = _velocity;
    }

    public void StopImmediately()
    {
        _velocity = Vector2.zero;
        _rigidbody.velocity = _velocity;
    }

    private void JumpHandle()
    {
        //! 폐기 ?
        if (Physics2D.Raycast(transform.position,
                Vector2.down, _rayDistance, _whatIsGround))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 1 * _jumpPower);
        }
    }

    private void HandleMaxChargeEvent(bool IsMax)
    {
        if (IsMax)
            IsMaxCharge = true;
        else
            IsMaxCharge = false;
    }

    private void CheckFall()
    {
        // 떨어지는 상황
        if (_rigidbody.velocity.y <= 0.1f)
        {
            isFall = true;
        }
        else
        {
            isFall = false;
        }
    }

    private void CheckJump()
    {
        if (_rigidbody.velocity.y >= 0.1f)  // 올라가는 상황
        {
            IsJump = true;
        }
        else
        {
            IsJump = false;
        }
    }

    private void CheckDown()
    {
        if (Keyboard.current.sKey.isPressed)
        {
            isDown = true;
        }
    }

    private void AttackHandle()
    {
        if (IsGround == false || IsAttack == false) return;

        _colliders = new Collider2D[30];
        int hit = Physics2D.OverlapBoxNonAlloc(transform.position, new Vector2(2, 2), 0, _colliders, _enemyLayer);

        if (hit > 0)
        {
            //CameraEffect.Instance.CameraShake();
            foreach (Collider2D enemy in _colliders)
            {
                foreach (Transform enemyTrmItem in _checkEnemyList)
                {
                    if (enemyTrmItem == enemy.transform)
                    {
                        return;
                    }
                }
                if (enemy != null)
                {
                    enemy.GetComponent<EnemyHealth>().DownHp(_playerHealth.PlayerStat.strength.GetValue(), transform.position);
                    _checkEnemyList.Add(enemy.transform);
                }
            }
        }
    }

    public bool isChargeAttack { get; set; }
    public bool isCharge { get; set; }
    private List<Transform> _checkEnemyList = new List<Transform>();

    public bool IsAttack { get; set; }

    public float rayDistance = 3f;

    private void ChargeAttackRay()
    {
        if (isChargeAttack == false || IsAttack == false) return;

        _colliders = new Collider2D[30];
        int hit = Physics2D.OverlapBoxNonAlloc(transform.position, new Vector2(1.3f, 1.3f), 0, _colliders, _enemyLayer);

        if (hit > 0)
        {
            foreach (Collider2D enemy in _colliders)
            {
                if (enemy)
                {
                    foreach (Transform enemyTrmItem in _checkEnemyList)
                    {
                        if (enemyTrmItem == enemy.transform)
                        {
                            return;
                        }
                    }

                    enemy.transform.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth);
                    if (enemyHealth != null)
                    {
                        Debug.Log($"Hit");
                        enemyHealth.DownHp(_playerHealth.PlayerStat.strength.GetValue(), transform.position);
                        _checkEnemyList.Add(enemy.transform);
                    }
                }
            }
        }
    }

    public void EndChargeAttackRay()
    {
        isChargeAttack = false;
        _checkEnemyList.Clear();
    }

    private void CheckGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _whatIsGround))
        {
            IsGround = true;  // 땅 감지
        }
        else
        {
            IsGround = false;
        }
    }

    public void StopDown()
    {
        isDown = false;
    }

    public void MoveSlow(bool IsSlow, float slowSpeed = 0f)
    {
        if (IsSlow)  // 슬로우 상태가 True이면?
        {
            _moveSpeed -= slowSpeed;  // 스피드 낮춤 / 슬로우
        }
        else
        {
            _moveSpeed = _originalMoveSpeed;  // 원래 스피드로
        }
    }

    public void MoveChargeAttack(bool Isdir)
    {
        // 여기서 차지 애니메이션에 맞춰 앞으로 돌진하는 코드 추가
        _isChargeAttack = true;
        // print("야 생각해 괜찮아");
        // 방향에 따라 돌진
        if (Isdir)
        {
            _rigidbody.velocity = new Vector2(_chargeAttackMovePower, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_chargeAttackMovePower, _rigidbody.velocity.y);
        }
    }

    public void EndChargeAttack()
    {
        _isChargeAttack = false;
        StopImmediately();
    }

    public void NoInput(bool isSetting)
    {
        if (isSetting)
        {
            _inputReader._playerActions.Player.Disable();
        }
        else
        {
            _inputReader._playerActions.Player.Enable();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * _rayDistance);
    }
}
