using System;

[Serializable]
public class FallingObjectData
{
    private float fallingVelocity;
    private float horizontalVelocity;

    public FallingObjectData(float fallingVelocity)
    {
        this.fallingVelocity = fallingVelocity;
    }

    public FallingObjectData(float fallingVelocity, float horizontalVelocity)
    {
        this.fallingVelocity = fallingVelocity;
        this.horizontalVelocity = horizontalVelocity;
    }

    public float GetFallingVelocity()
    {
        return fallingVelocity;
    }

    public float GetHorizontalVelocity()
    {
        return horizontalVelocity;
    }

}
