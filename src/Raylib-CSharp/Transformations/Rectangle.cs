using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_CSharp.Transformations;

[StructLayout(LayoutKind.Sequential)]
public struct Rectangle {

    /// <summary>
    /// Rectangle top-left corner position x.
    /// </summary>
    public float X;

    /// <summary>
    /// Rectangle top-left corner position y.
    /// </summary>
    public float Y;

    /// <summary>
    /// Rectangle width.
    /// </summary>
    public float Width;

    /// <summary>
    /// Rectangle height.
    /// </summary>
    public float Height;

    /// <summary>
    /// Rectangle, 4 components.
    /// </summary>
    /// <param name="x">The x-coordinate of the rectangle.</param>
    /// <param name="y">The y-coordinate of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    public Rectangle(float x, float y, float width, float height) {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public Rectangle(ConstructMode mode, Vector2 left, Vector2 right) {
        switch (mode) {
            case ConstructMode.Centered:
                this.X = left.X - (right.X / 2);
                this.Y = left.Y - (right.Y / 2);
                this.Width = right.X;
                this.Height = right.Y;
                break;
            case ConstructMode.TopLeftScale:
                this.X = left.X;
                this.Y = left.Y;
                this.Width = right.X;
                this.Height = right.Y;
                break;
            case ConstructMode.TopLeftBottomRight:
                this.X = left.X;
                this.Y = left.Y;
                this.Width = right.X - left.X;
                this.Height = right.Y - left.Y;
                break;
        }
    }

    /// <summary>
    /// Gets or sets the position of the top-left corner of the rectangle.
    /// </summary>
    /// <value>The position of the top-left corner of the rectangle.</value>
    public Vector2 Position {
        get => new Vector2(this.X, this.Y);
        set {
            this.X = value.X;
            this.Y = value.Y;
        }
    }

    /// <summary>
    /// Gets or sets the size of the rectangle.
    /// </summary>
    /// <value>A Vector2 representing the width and height of the rectangle.</value>
    public Vector2 Size {
        get => new Vector2(this.Width, this.Height);
        set {
            this.Width = value.X;
            this.Height = value.Y;
        }
    }

    public override string ToString() {
        return $"X:{this.X} Y:{this.Y} Width:{this.Width} Height:{this.Height}";
    }

    public enum ConstructMode {
        Centered,
        TopLeftScale,
        TopLeftBottomRight
    }
}