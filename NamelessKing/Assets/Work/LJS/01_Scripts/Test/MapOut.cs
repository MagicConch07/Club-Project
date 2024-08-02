using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapOut : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Image _fadeImage;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.transform.position = startPos.position;
        }
    }
}
