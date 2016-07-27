using UnityEngine;
using System.Collections;

public class CameraIOS : MonoBehaviour {
    public float moveSensityX = 1.0f;
    public float moveSensityY = 1.0f;
    public bool updateZoomSensity = true;
    public float orthoZoomSpeed = 0.05f;
    public float minZoom = 1.0f;
    public float maxZoom = 20.0f;
    public bool invertMoveX = false;
    public bool invertMoveY = false;

   
    public Camera _camera;
    // Use this for initialization
    void Start () {
 

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (updateZoomSensity)
        {
            moveSensityX = _camera.orthographicSize / 5.0f;
            moveSensityY = _camera.orthographicSize / 5.0f;

        }
        Touch[] touches = Input.touches;
        if (touches.Length>0)
        {
            if (touches.Length == 1)
            {
                if (touches[0].phase == TouchPhase.Moved)
                {
                    Vector2 delta = touches[0].deltaPosition;

                    float positionX = delta.x * 50 * Time.deltaTime;
                    positionX = invertMoveX ? positionX : positionX * -1;

                    float positionY = delta.y * 50 * Time.deltaTime;
                    _camera.transform.position += new Vector3(positionX,positionY,0);
                }
            }


           /* if (touches.Length == 2)
            {
                Touch touchOne = touches[0];
                Touch touchTwo = touches[1];

                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
                Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;

                float prevTouchDeltaMag = (touchOnePrevPos - touchTwoPrevPos).magnitude;
                float touchDeltaMag = (touchOne.position - touchTwo.position).magnitude;

                float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

                _camera.orthographicSize += deltaMagDiff*orthoZoomSpeed;
                _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, minZoom, maxZoom);
            }
            */

        }
	}
}
