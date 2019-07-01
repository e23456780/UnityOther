using UnityEngine;

public class CameraRectPos
{
    static Camera cam;
    static Transform floor;

    /// <summary>
    /// 用來取得攝影機對於目標(通常是地板) 
    /// Used to get the camera for the target (usually the floor)
    /// 所包含的範圍(以y軸為例)
    /// range  (take the y-axis as an example)
    /// </summary>
    /// <param name="_cam"></param>
    /// <param name="_floor"></param>
    /// <returns></returns>
    public static Vector3[] GetCamerRect(Camera _cam, Transform _floor)
    {
        cam = _cam;
        floor = _floor;

        Vector3 p1 = ScenePos(cam.pixelWidth - 1, cam.pixelHeight - 1);
        Vector3 p2 = ScenePos(0.0f, cam.pixelHeight - 1);
        Vector3 p3 = ScenePos(0.0f, 0.0f);
        Vector3 p4 = ScenePos(cam.pixelWidth - 1, 0.0f);
        return new Vector3[] { p1, p2, p3, p4 };
    }

    static Vector3 ScenePos(float width, float height)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(width, height));
        float _h = ray.origin.y - floor.transform.position.y;
        _h = Mathf.Abs(_h / ray.direction.y);
        return ray.GetPoint(_h);
    }
}

