using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineConfiner cinemachineConfiner;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineConfiner = GetComponent<CinemachineConfiner>();
    }

    private void Start()
    {
        SetPlayerAndBackground();
    }

    public void SetPlayerAndBackground()
    {
        virtualCamera.Follow = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_TAG).transform;
        cinemachineConfiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag(GameConstants.BACKGROUND_TAG).GetComponent<PolygonCollider2D>();
    }

}
