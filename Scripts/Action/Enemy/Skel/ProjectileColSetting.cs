using ObjectPooling;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileColSetting : MonoBehaviour
{
    // later use PoolableMono

    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _damage;
    private Rigidbody2D _rg2d;

    private void Awake(){
        _rg2d = GetComponent<Rigidbody2D>();
    }
    
    public void Init() {
        _rg2d.velocity = new Vector2(_projectileSpeed * transform.localScale.x, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent(out PlayerHealth playerHealth)){
            playerHealth.DownHp(_damage);
            Health_UI.Instance.OnHit(_damage);
        }
        if(other.gameObject.CompareTag("Player")){
            if(_hitEffect) Instantiate(_hitEffect, transform.position, Quaternion.identity);
            SoundManager.Instance.StartHitImpactSource();
            Destroy(gameObject);
        }
    }
}
