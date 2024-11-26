using UnityEngine;

// 형식 제약 조건 싱글톤은 T값을 매개변수로 갖고 모노비헤이버를 상속받아 그러면서 형식이 컴포넌트여야 해
public class StudySingleton<T> : MonoBehaviour where T : Component
{
    // private 스태틱 T 인스턴스
    private static T _instance;

    // 인스턴스 프로퍼티
    public static T Instance
    {
        // 게터
        get
        {
            // 만약 인스턴스가 존재하지 않는다면
            if (_instance == null)
            {
                // 인스턴스를 생성된 오브젝트 중에서 찾아
                _instance = FindObjectOfType<T>();

                // 그래도 만약 없다면 / 새로 만들어야 함
                if (_instance == null)
                {
                    // obj를 생성
                    GameObject obj = new GameObject();
                    // obj이름을 싱글톤 이름으로 / 어짜피 싱글톤은 하나니까
                    obj.name = typeof(T).Name;
                    // 그리고 싱글톤한 컴포넌트 추가 및 인스턴스에 넣어줘
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        // 시작해서 만약에 인스턴스가 없으면
        if (_instance == null)
        {
            // T가 뭔지 모르니 as 연산자로 실패하면 Null이 들어가게 자기 자신을 형식변환해서 인스턴스에 넣어줌
            // T는 타입이니 T를 그냥 넘겨주면 유효하지 않다. 그러므로 자기 자신을 T로 as 연산자로 타입캐스트해서 실패하면 Null 아니면 _instance가 무슨 타입인지 알게끔
            _instance = this as T;
            //_instance = T;
            // 게임 씬 변경이 일어나도 불변이 되야되기 때문에 게임오브젝트를 넣음
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 만약 오브젝트가 존재하면 한개만 존재해야 하니 파괴
            Destroy(this.gameObject);
        }
    }

    public virtual void Start()
    {
        // 시작해서 만약에 인스턴스가 없으면
        if (_instance == null)
        {
            // T가 뭔지 모르니 as 연산자로 실패하면 Null이 들어가게 자기 자신을 형식변환해서 인스턴스에 넣어줌
            // T는 타입이니 T를 그냥 넘겨주면 유효하지 않다. 그러므로 자기 자신을 T로 as 연산자로 타입캐스트해서 실패하면 Null 아니면 _instance가 무슨 타입인지 알게끔
            _instance = this as T;
            //_instance = T;
            // 게임 씬 변경이 일어나도 불변이 되야되기 때문에 게임오브젝트를 넣음
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 만약 오브젝트가 존재하면 한개만 존재해야 하니 파괴
            Destroy(this.gameObject);
        }
    }
}
