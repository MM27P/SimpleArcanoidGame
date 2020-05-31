using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PointScript : MonoBehaviour
{
    [SerializeField]
    private int value;
    [SerializeField]
    private PointsController pointsController;
    [SerializeField]
    private int id;
    public int Id { get { return id; } set{ id = value; } }

    private void Start()
    {
        pointsController = gameObject.GetComponentInParent<PointsController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameController.Instance.AddScore(value);
            pointsController.UpdatePointsInstanceCount();
            Destroy(gameObject);
        }
    }
}
