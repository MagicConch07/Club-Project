using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using CYH;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyInfoSO _enemyInfoSO;
    [SerializeField] private float changeMatTime = 0.5f;
    [SerializeField] private float knockBackPower;

    public Action<EnemyHealth> OnDeath;

    public bool IsHit { get; set; } = false;
    private float _currentHp = 0;
    private Coroutine _coroutine;

    #region Compoent
    private Animator _animator;
    private Rigidbody2D _rigid2d;
    private SpriteRenderer _sp;
    private BoxCollider2D _boxCol;
    private BehaviorTree _behaviorTree;
    private FieldOfView _fieldOfView;
    private BoxCollider2D _footCol;
    #endregion
    

    private void Awake() {
        #region GetCompo
        Transform visual = transform.Find("Visual");
        _animator = visual.GetComponent<Animator>();
        _sp = visual.GetComponent<SpriteRenderer>();
        _rigid2d = GetComponent<Rigidbody2D>();
        _behaviorTree = GetComponent<BehaviorTree>();
        _boxCol = GetComponent<BoxCollider2D>();
        _fieldOfView = GetComponent<FieldOfView>();
        _footCol = transform.Find("FootCol").GetComponent<BoxCollider2D>();  
        #endregion
    }

    private void Start() {
        _currentHp = _enemyInfoSO._enemyInfo.hp;
    }
    
    private void Update() {

    }

    public void StartHitAction(){
        IsHit = true;
        AnimationManager.Instance.ChangeAnimationBool(_animator, "Hit");

        if(_sp.material.GetInt("_IsWhite") != 1){
            ChangeWhiteMat();
        }   
    }

    public void ChangeWhiteMat(){
        _coroutine = StartCoroutine(StartWhiteMat());
    }

    private IEnumerator StartWhiteMat(){

        _sp.material.SetInt("_IsWhite", 1);
        yield return new WaitForSeconds(changeMatTime);
        _sp.material.SetInt("_IsWhite", 0);;
    }

    public void DownHp(float downValue, Vector3 targetPos){
        Vector3 normal = (transform.position - targetPos).normalized;
        normal.y = 0;
        
        _rigid2d.AddForce(normal * knockBackPower, ForceMode2D.Impulse);
        _currentHp -= downValue;
        if(_currentHp < 0){
            DieAction();
        }
        IsHit = true;
    }

    private void DieAction(){
        _rigid2d.velocity = Vector2.zero;
        _footCol.enabled = true;
        _rigid2d.gravityScale = 1f;

        _behaviorTree.enabled = false;
        _boxCol.enabled = false;
        _fieldOfView.enabled = false;

        AnimationManager.Instance.ChangeAnimationBool(_animator, "Die");
        this.enabled = false;

        OnDeath?.Invoke(this);
    }

    public void HealHp(float healValue){
        _currentHp += healValue;
    }
}
