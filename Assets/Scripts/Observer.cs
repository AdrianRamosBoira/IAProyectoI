﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public GameEnding gameEnding;

    Transform player;
    MovimientoFantasmas ghost;
    bool m_IsPlayerInRange;

    private void Start()
    {
        ghost = GetComponentInParent<MovimientoFantasmas>();
        player = GameObject.Find("JohnLemon").transform;
    }

    //cuando algo entra en su campo de visión comprueba si se trata del jugador
    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }
    //cuando algo sale del campo de visión deja de ver
    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update ()
    {
        //si el jugador está en el campo de visión
        if (m_IsPlayerInRange)
        {
            //manda un raycast para confirmar que el jugador está en el campo de visión
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            //si confirma que está en el campo de visión hace cosas
            if (Physics.Raycast (ray, out raycastHit))
            {
                Debug.Log("Fantasma ve: " + raycastHit.collider.tag);
                if (raycastHit.collider.transform == player && (ghost.consultaEstadoFantasma() == EstadoNPC.Patrolling || ghost.consultaEstadoFantasma() == EstadoNPC.GoingPatrol) )
                {
                    ghost.AvisoDeFantasma();
                }
            }
        }
    }
}
