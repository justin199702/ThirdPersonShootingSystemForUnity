﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{
    public event System.Action<Player> OnLocalPlayerJoined;
    private GameObject gameObject;
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
            }
            return m_Instance;
        }
    }

    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
            
                m_InputController = gameObject.GetComponent<InputController>();
                return m_InputController;
            
        }
    }
    private Player m_Player;
    public Player LocalPlayer
    {
        get
        {
            return m_Player;
        }
        set
        {
            m_Player = value;
            if (OnLocalPlayerJoined != null)
                OnLocalPlayerJoined(m_Player); 
        }
    }
}
