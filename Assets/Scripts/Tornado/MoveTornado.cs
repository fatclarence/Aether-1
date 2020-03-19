﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;

public class MoveTornado : SkillsBehavior
{
    [SerializeField]
    private float m_Speed = 15f;

    private Vector3 m_CurrentDirection;

    private void Start()
    {
        m_CurrentDirection = PlayerManager.Instance.GetLocalPlayer().transform.forward.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (!networkObject.IsOwner)
        {
            transform.position = networkObject.position;
            return;
        }

        // Called by owner of tornado spell
        transform.position += m_CurrentDirection * Time.deltaTime * m_Speed;
        networkObject.position = transform.position;
    }

}
