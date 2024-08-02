using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.Events;

public class SharedValueManager : MonoBehaviour
{
    public static SharedValueManager Instance;

    private SharedTransform playerTrm;
    public SharedTransform PlayerTrm
    {
        get
        {
            playerTrm = GameObject.FindWithTag("Player").transform;
            return playerTrm;
        }
        private set
        {

        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{Instance} is Running Another GameObject");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        PlayerTrm = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"{Instance} is Running Another GameObject");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        PlayerTrm = GameObject.FindWithTag("Player").transform;
    }
}
