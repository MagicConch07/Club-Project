using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour, IShowGizmos
{
	[SerializeField] private LayerMask _whatIsplayer;
    [SerializeField] private float _viewAngle;
    [SerializeField] private float _viewRadius;
    [SerializeField] private bool _showGizoms = false;
    
    [SerializeField] private LayerMask _whatIsObstacle;

    public bool IsViewPlayer {get; set;} = false;

    private Collider2D visibleTaget;
    private float _lastCheckTime;
    private float dirx;
    [SerializeField] private float _stopChaseTime = 3.5f;

    private void Awake() {
        IsViewPlayer = false;
    }

    private void Update()
    {
        if(IsViewPlayer && CheckFleidView()){
            Debug.DrawLine(transform.position, visibleTaget.transform.position);
            _lastCheckTime = Time.time;
            return;
        }
        else if(IsViewPlayer && !CheckFleidView())
        {
            if(Time.time - _lastCheckTime > _stopChaseTime){
                IsViewPlayer = false;
                return;
            }
        }
        CheckFleidView();
    }

    private Collider2D CheckFleidView(){
        visibleTaget = Physics2D.OverlapCircle(transform.position, _viewRadius, _whatIsplayer);

        if(!visibleTaget) return null;
        
        float dirx = Mathf.Clamp(transform.localScale.x, -1, 1);
        Vector3 dir = (visibleTaget.gameObject.transform.position
                            - transform.position).normalized;
        if(Vector2.Angle(transform.right * dirx, dir) < _viewAngle / 2)
        {
            float dirTotarget = Vector3.Distance(visibleTaget.gameObject.transform.position, 
                                    transform.position);

            if(!Physics2D.Raycast(transform.position, dir, dirTotarget, _whatIsObstacle)){
                IsViewPlayer = true;
                return visibleTaget;
            }
            else{
                return null;
            }
        }
        return null;
    }

    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }

    private void OnDrawGizmos()
    {
        if(!ShowGizoms()) return;
        Vector3 viewAngleA = DirFromAngle(-_viewAngle / 2, false);
		Vector3 viewAngleB = DirFromAngle(_viewAngle / 2, false);

        float dirx = Mathf.Clamp(transform.localScale.x, -1, 1);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _viewRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, 
            transform.position + (viewAngleA * dirx) * _viewRadius);
        Gizmos.DrawLine(transform.position, 
            transform.position + (viewAngleB * dirx) * _viewRadius);
    }

    public bool ShowGizoms()
    {
        // Debug.Log($"this Script Gizoms State is{_showGizoms}");
        return _showGizoms;
    }
}