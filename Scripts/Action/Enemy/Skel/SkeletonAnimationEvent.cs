using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using BehaviorDesigner.Runtime;

public class SkeletonAnimationEvent : MonoBehaviour
{
    [Header("HelathSetting")]
    [SerializeField] private EnemyInfoSO _enemyInfoSO;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private float _fadeTime;

    [Header("Projectile Setting")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;

    [Header("Necromancer Setting")]
    [SerializeField] private GameObject _warnningPrefab;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private GameObject _explosionPrefab;

    [Header("OverlapSetting")]
    [SerializeField] private Vector2 _slashCheckSize;
    [SerializeField] private Vector2 _biteCheckSize;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private Transform _attackTrm;

    private Animator _animator;
    private SpriteRenderer _sp;
    private BoxCollider2D _enenmyCol;
    private BehaviorTree _behaviorTree;
    private Vector3 objPoint;

    private void Awake() {
        Transform Vparent = transform.parent;
        _animator = GetComponent<Animator>();
        _sp = GetComponent<SpriteRenderer>();
        _enenmyCol = Vparent.GetComponent<BoxCollider2D>();
        _behaviorTree = Vparent.GetComponent<BehaviorTree>();
    }

    private void Start(){
        _enemyInfoSO._enemyInfo.currentCoolTime = 0;
    }
    
    private void HpDown(Collider2D col){
        if(col.TryGetComponent(out PlayerHealth playerHealth)){
            playerHealth.DownHp(_enemyInfoSO._enemyInfo.power);
            Health_UI.Instance.OnHit(_enemyInfoSO._enemyInfo.power);

        }
    }

    private void SlashAttackCheck(){
        Collider2D col2D = Physics2D.OverlapBox(_attackTrm.position, _slashCheckSize, 0, _whatIsPlayer);
        if(col2D){
            HpDown(col2D);
            SoundManager.Instance.StartStingSoruce();
        }
    }

    private void BiteAttackCheck(){
        Collider2D col2D = Physics2D.OverlapBox(_attackTrm.position, _biteCheckSize, 0, _whatIsPlayer);
        if(col2D){
            HpDown(col2D);
            SoundManager.Instance.StartBiteAttackSoruce();
        }
    }

    private void PlayMagicSound(){
        SoundManager.Instance.StartFireBallSoruce();
    }

    private void AttackEnd(){
        _enemyInfoSO._enemyInfo.currentCoolTime = Time.time;
    }

    private void NAttackEnd(){
        _enemyInfoSO._enemyInfo.currentCoolTime = Time.time;
        _animator.SetBool("Attack", false);
        Instantiate(_explosionPrefab, objPoint, Quaternion.identity);
        Collider2D col2d = Physics2D.OverlapCircle(objPoint, 0.7f, _whatIsEnemy);
        if(col2d){
            HpDown(col2d);
        }
    }

    private void NAttackStart(){
        Transform playerTrm = GameObject.FindWithTag("Player").transform;
        GameObject obj = Instantiate(_warnningPrefab, playerTrm.position, Quaternion.identity);
        objPoint = obj.transform.position;
    }

    private void CreateArrow(){
        GameObject obj = Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity);
        float dirX = Mathf.Clamp(transform.parent.localScale.x, -1, 1);
        obj.transform.localScale = new Vector3(dirX, 1, 1);
        if(!obj.TryGetComponent(out ProjectileColSetting projectile)){
            return;
        }
        projectile.Init();
    }
    
    private void DeadEnd(){
        _sp.DOFade(0, _fadeTime).OnComplete(() =>{
            // later Add Pool And Use Fuc Push
            transform.parent.gameObject.SetActive(false);
        });
    }

    private void HitEnd(){
        _enemyHealth.IsHit = false;
        _animator.SetBool("Hit", false);
    }

    private void ReviveEnd(){
        Debug.Log($"{transform.parent}");
        _animator.SetBool("Revive", false);
        _enenmyCol.enabled = true;
        _behaviorTree.enabled = true;
    }

    private void PlayArcherSound(){
        SoundManager.Instance.StartArherAttackSoruce();
    }
}
