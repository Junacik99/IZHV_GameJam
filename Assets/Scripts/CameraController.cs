using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float borderTreshold = 0.05f;
    [SerializeField]
    private float moveSpeed = 7f;
    [SerializeField]
    private float closeZoom = 15;
    [SerializeField]
    private float farZoom = 50;
    public class ScreenBorder
    {
        public float up;
        public float bottom;
        public float left;
        public float right;
    }
    ScreenBorder screenBorder = new ScreenBorder();

    Transform _transform;
    private void Awake()
    {
        Vector2Int screen = new Vector2Int(Screen.width, Screen.height);
        if(borderTreshold>1f)
            borderTreshold = 1f;
        float uppperBorderTreshold = 1f - borderTreshold;
        
        // Calculate screen border for mouse controls
        screenBorder.up = screen.y * uppperBorderTreshold;
        screenBorder.bottom = screen.y * borderTreshold;
        screenBorder.left = screen.x * borderTreshold;
        screenBorder.right = screen.x * uppperBorderTreshold;

        _transform = GetComponent<Transform>();

        //Debug.Log($"up: {screenBorder.up}\ndown: {screenBorder.bottom}\nright{screenBorder.right}\nleft: {screenBorder.left}");
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        Vector3 mp = Input.mousePosition;

        if(mp.y > screenBorder.up)
        {
            if (_transform.position.z < 900)
                _transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);  
        }
        else if(mp.y < screenBorder.bottom)
        {
            if (_transform.position.z > 100)
                _transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }
        if (mp.x > screenBorder.right)
        {
            if (_transform.position.x < 900)
                _transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
        else if (mp.x < screenBorder.left)
        {
            if (_transform.position.x > 100)
                _transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }

        // Zoom
        if(Input.mouseScrollDelta.y > 0)
        {
            if(_transform.position.y > closeZoom)
                _transform.position = new Vector3(_transform.position.x, _transform.position.y - 2f, _transform.position.z);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if(_transform.position.y < farZoom)
                _transform.position = new Vector3(_transform.position.x, _transform.position.y + 2f, _transform.position.z);
        }

        // Reset camera to player
        if (Input.GetKeyDown(KeyCode.C))
        {
            _transform.position = new Vector3(player.position.x, _transform.position.y, player.position.z);
        }
    }
}
