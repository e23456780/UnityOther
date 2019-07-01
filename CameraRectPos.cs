using UnityEngine;

public class CameraRectPos
{
    static Camera cam;
    static Transform tag;
    public static Vector3[] GetCamerRect(Camera _cam, Transform _tag)
    {
        cam = _cam;
        tag = _tag;

        Vector3 p1 = ScenePos(cam.pixelWidth - 1, cam.pixelHeight - 1);
        Vector3 p2 = ScenePos(0.0f, cam.pixelHeight - 1);
        Vector3 p3 = ScenePos(0.0f, 0.0f);
        Vector3 p4 = ScenePos(cam.pixelWidth - 1, 0.0f);
        return new Vector3[] { p1, p2, p3, p4 };
    }

    static Vector3 ScenePos(float width, float height)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(width, height));
        float _h = ray.origin.y - tag.transform.position.y;
        _h = Mathf.Abs(_h / ray.direction.y);
        return ray.GetPoint(_h);
    }
}
