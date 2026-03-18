namespace ConsoleApp1;

public class Camera : Equipment
{
    public string LensSize { get; set; }
    public string CameraType { get; set; }

    public Camera(string name) : base(name)
    {
    }
}
