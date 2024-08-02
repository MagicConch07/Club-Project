// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class Test{

//     private void Start() {
//         SceneManager.sceneLoaded += 
//     }
// }


// using DG.Tweening;
// using TMPro;
// using UnityEngine.Playables;

// public class SceneManagmant
// {

//     public static SceneManagmant instance;

//     private Transform m_transfom;
//     private string[] sceneName;

//     public SceneManagmant(Transform trm, Canvas _MapName, SceneInfo _sceneInfo, string[] name)
//     {
//         m_transfom = trm;
//         canvaMN = _MapName;
//         sceneInfo = _sceneInfo;
//         sceneName = name;


//         #region Component
//         frame = canvaMN.transform.Find("MapName").GetComponent<Image>();
//         mapName = frame.transform.Find("Name").GetComponent<TextMeshProUGUI>();
//         mapToolTip = frame.transform.Find("ToolTip").GetComponent<TextMeshProUGUI>();
//         #endregion

//         #region AwakeAction
//         for (int i = 0; i < sceneName.Length; i++)
//         {
//             sceneInfo.infos.Add(sceneName[i], sceneInfo.sceneInfos[i]);
//         }
//         #endregion

//         #region AwakeEvent
//         SceneManager.sceneLoaded += ViewMapName;
//         #endregion
//     }

//     private SceneInfo sceneInfo;

//     private Canvas canvaMN;
//     private Image frame;
//     private TextMeshProUGUI mapName;
//     private TextMeshProUGUI mapToolTip;

//     private GameObject player;

//     private void ViewMapName(Scene arg0, LoadSceneMode arg1) // 맵에 들어갈 시 위쪽에 이미지와 함께 텍스트가등장
//     {

//         if (!sceneInfo.infos.ContainsKey(arg0.name))
//         {
//             GameManager.Instance.Instage = false;
//             return;
//         }

//         if (arg0.name == "Lobby")
//         {
//             if (PlayerPrefs.GetInt("ScenePlay") <= 1)
//             {
//                 PlayerPrefs.SetInt("ScenePlay", ++GameManager.Instance.ScenePlay);
//                 if (GameObject.Find("TimeLine").TryGetComponent(out PlayableDirector playableDirector))
//                 {
//                     playableDirector.Play();
//                 }
//             }

//             this.player = GameManager.Instance.player;
//             player.SetActive(true);
//             player.GetComponent<PlayerController>().enabled = true;
//             player.transform.position = GameObject.Find("LobbyPoint").transform.position;
//         }

//         if(arg0.name == "Stage1")
//         {
//             GameManager.Instance.Instage = true;
//             player.GetComponent<PlayerController>().enabled = true;
//             player.GetComponent<PlayerController>().coolTime = GameObject.FindObjectOfType<CoolTime>();
//             player.GetComponent<PlayerAttack>().enabled = true;
//             player.GetComponent<PlayerJump>().enabled = true;
//             player.GetComponent<PlayerSkill>().enabled = true;
//             player.GetComponent<PlayerHp>().enabled = true;
//             player.GetComponent<PlayerHp>().hpImage = GameObject.Find("Hp").GetComponent<Image>();
//         }

//         Debug.Log("실행");

//         mapName.text = sceneInfo.infos[arg0.name].name.Replace("\\n", "\n");
//         mapToolTip.text = sceneInfo.infos[arg0.name].tooltip.Replace("\\n", "\n");

//         Sequence seq = DOTween.Sequence();

//         seq.Append(frame.DOColor(new Color(frame.color.r, frame.color.g, frame.color.b, 0.8f), 1f));
//         seq.Append(mapName.DOColor(new Color(frame.color.r, frame.color.g, frame.color.b, 0.8f), 1f));
//         seq.Append(mapToolTip.DOColor(new Color(frame.color.r, frame.color.g, frame.color.b, 0.8f), 1f));

//         seq.AppendInterval(3f);

//         seq.Append(frame.DOColor(Vector4.zero, 1.5f));
//         seq.Join(mapName.DOColor(Vector4.zero, 1.5f));
//         seq.Join(mapToolTip.DOColor(Vector4.zero, 1.5f));
//     }
// }

// [Serializable]
// public struct Info
// {
//     public string name;
//     public string tooltip;
// }

// [CreateAssetMenu(menuName = "SO/SceneInfo")]
// public class SceneInfo : ScriptableObject
// {
//     public Info[] sceneInfos;
//     public Dictionary<string, Info> infos = new();
// }