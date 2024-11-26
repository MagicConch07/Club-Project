using CYH;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using DG.Tweening;


public class EnemyRevive : MonoBehaviour
{
    [SerializeField] private GameObject _spawnEffect;
    private Animator _animator;
    private BehaviorTree _behaviourTree;
    private BoxCollider2D _enemyCol;
    private SpriteRenderer _sp;

    public void ReviveAction(){
        Transform visualTrm = transform.Find("Visual");
        Transform footCol = transform.Find("FootCol");
        Vector3 pos = new Vector3(footCol.position.x, footCol.position.y + 0.7f);
        Instantiate(_spawnEffect, pos, Quaternion.identity);
        _sp = visualTrm.GetComponent<SpriteRenderer>();
        _sp.color = new Color(_sp.color.r, _sp.color.g, _sp.color.b, 0);
        _sp.DOFade(1, 1.5f);
        _animator = visualTrm.GetComponent<Animator>();
        AnimationManager.Instance.ChangeAnimationBool(_animator, "Revive");
        
        _behaviourTree = GetComponent<BehaviorTree>();
        _behaviourTree.enabled = false;
        _enemyCol = GetComponent<BoxCollider2D>();
        _enemyCol.enabled = false;
        
    }
}
