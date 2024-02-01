using System.Numerics;
using Raylib_cs;

namespace FnaF;

public class Button
{
    Action hoverAction;
    Action clickAction;
    Rectangle rect;

    Vector2 mousePos;

    public Button(Rectangle rectangle, Action hoverAct, Action clickAct)
    {
        rect = rectangle;
        hoverAction = hoverAct;
        clickAction = clickAct;
    }

    public void Update(Vector2 mP)
    {
        mousePos = mP;

        if(CheckOverlap())
        {
            hoverAction();

            if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                clickAction();
            }
        }
    }

    bool CheckOverlap()
    {
        return Raylib.CheckCollisionPointRec(mousePos, rect);
    }
}
