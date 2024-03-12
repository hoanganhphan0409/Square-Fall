using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    public Vector2 StartPos => startPos.position;
    public Vector2 EndPos => endPos.position;
}
