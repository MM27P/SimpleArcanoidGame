using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PointsController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pointsList;
    [SerializeField]
    private int pointsIstanceCount;

    // Start is called before the first frame update
    void Awake()
    {
        int index = 0;
        var temp = gameObject.GetComponentsInChildren<PointScript>().ToList();
        temp.ForEach(x => x.Id = ++index);
        pointsList = temp.Select(x => x.gameObject).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        pointsIstanceCount = pointsList.Count;
    }
    public void UpdatePointsInstanceCount()
    {
        if (CheckNoPointsMore())
        {
            GameController.Instance.WinGame();
        }
        else
            pointsIstanceCount = pointsList.Count;

    }
    private bool CheckNoPointsMore()
    {
        return pointsList == null || pointsList.Count == 0;
    }

    public List<int> GetPointsInstancesList()
    {
        return pointsList.Where(x=>x!=null).Select(x => x.GetComponent<PointScript>().Id).ToList();
    }

    public void LoadPointsInstancesList(List<int> pointsIdList)
    {
        List<GameObject> objectsToDelete = new List<GameObject>();
        foreach (var pointInstance in pointsList)
        {
            if (!pointsIdList.Contains(pointInstance.GetComponent<PointScript>().Id))
            {              
                objectsToDelete.Add(pointInstance);
            }
        }

        foreach (var delete in objectsToDelete)
        {
            pointsList.Remove(delete);
            Destroy(delete);
        }

        UpdatePointsInstanceCount();
    }
}
