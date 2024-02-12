using System.Numerics;
using Raylib_cs;

namespace FnaF;

public class Button
{
    Action hoverAction;
    Action clickAction;
    Rectangle rect;

    Vector2 mousePos;

    // TODO: Fix so that not all buttons need a hover action HUR??!?!?!?!??!?!

    public Button(Rectangle rectangle, Action hoverAct, Action clickAct)
    {
        rect = rectangle;
        hoverAction = hoverAct;
        clickAction = clickAct;
    }

    public void Update(Vector2 mP)
    {
        mousePos = mP;

        if (CheckOverlap())
        {
            hoverAction();

            Click();
        }
    }


    void Click()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            clickAction();
        }
    }


    bool CheckOverlap()
    {
        return Raylib.CheckCollisionPointRec(mousePos, rect);
    }
}
