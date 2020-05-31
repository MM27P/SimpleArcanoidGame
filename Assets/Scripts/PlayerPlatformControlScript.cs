using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformControlScript : MonoBehaviour
{
    [SerializeField]
    private KeyCode LeftMoveKey = KeyCode.A;
    [SerializeField]
    private KeyCode RightMoveKey = KeyCode.D;
    [SerializeField]
    private float movePower = 0.5f;
    [SerializeField]
    private GameObject LeftBorderInstace;
    [SerializeField]
    private GameObject RightBorderInstace;

    private float range;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        range = renderer.bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlatform();
    }

    private void ControlPlatform()
    {
        if (Input.GetKey(LeftMoveKey))
        {
            if (CheckBorder1())
                MovePlatform(-movePower);
        }

        if (Input.GetKey(RightMoveKey))
        {
            if (CheckBorder2())
                MovePlatform(movePower);
        }
    }

    private void MovePlatform(float move)
    {
        float currentXPosition = transform.position.x;
        float border1X = LeftBorderInstace.transform.position.x;
        float border2X = RightBorderInstace.transform.position.x;

        currentXPosition += move;

        if (currentXPosition + range < border1X)
            currentXPosition = border1X + range;
        if (currentXPosition - range > border2X)
            currentXPosition = border2X - range;

        transform.position = new Vector3(currentXPosition, transform.position.y, transform.position.z);
    }

    private bool CheckBorder1()
    {
        float currentXPosition = transform.position.x;
        float border1X = LeftBorderInstace.transform.position.x;
        if (currentXPosition + range < border1X)
        {
            return false;
        }
        return true;
    }

    private bool CheckBorder2()
    {
        float currentXPosition = transform.position.x;
        float border2X = RightBorderInstace.transform.position.x;
        if (currentXPosition - range > border2X)
        {
            return false;
        }
        return true;
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public void SetCurrentPosition(Vector3 position)
    {
        transform.position = position;
    }
}
