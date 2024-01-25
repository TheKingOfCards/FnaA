public class Hugo : Animatronic
{
    public Hugo(int moveOp, int tM)
    {
        this.moveOp = moveOp;
        timerMax = tM;
        name = "Hugo";
        pathID = "Right";
    }

    public override void Move()
    {
        base.Move();
    }
}