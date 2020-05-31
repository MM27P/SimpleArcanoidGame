using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveFileObject
{
    [SerializeField]
    public int gameController_LifeCounts;
    [SerializeField]
    public int gameController_Score;
    [SerializeField]
    public List<int> pointsIdsInstance;
    [SerializeField]
    public Vector3 ball_Position;
    [SerializeField]
    public Vector3 ball_Velocity;
    [SerializeField]
    public Vector3 platform_Position;
}
