using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public float cameraSpeed = 3.0f;
    public GameObject Player;

    public float minX;
    public float minY;
    public float maxY;
    public float maxX;
    private void Awake()
    {
        if (DontDestroyobject.instance.Chaselected == 1)
        {
            Player = Instantiate(Resources.Load("Character/SeiKo_32")) as GameObject;
        }

        if (DontDestroyobject.instance.Chaselected == 2)
        {
            Player = Instantiate(Resources.Load("Character/RUNA_2")) as GameObject;
        }
        else return;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(Player != null)
        {
            float clampedX = Mathf.Clamp(Player.transform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(Player.transform.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), cameraSpeed);
        }
    }
}
