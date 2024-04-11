using FnaF;
using Raylib_cs;

public class Animatronic
{
    protected int _moveOp;

    //Timer variabels
    float _deltaTime;
    float _timer;
    protected float _timerMax;
    public List<Texture2D> deathAnimation = new();

    // Movement variabels
    protected List<int> _positions = new();
    protected int listIndex = 0;
    public int currentPosition = 8; // Is 8 becuse start pos
    public Dictionary<string, Texture2D> cameraImg = new();



    public void Update()
    {
        _deltaTime = GameFunctions.GetdeltaTime();

        Move();
    }


    protected virtual void Move()
    {
        if (_timer >= _timerMax)
        {
            _timer = 0;

            Console.WriteLine(currentPosition);

            if (GameFunctions.CheckRandom(1, 21, _moveOp))
            {
                if (GameFunctions.CheckRandom(1, 101, 50)) // Random check for if animatronic should move forward or backwards
                {
                    if (listIndex <= _positions.Count - 2 && listIndex >= 0) // Prevents out of range error
                    {
                        if (currentPosition == 8) // Checks if animatronic is in start position and starts movement
                        {
                            currentPosition = _positions[listIndex];
                        }
                        else
                        {
                            listIndex++;
                            currentPosition = _positions[listIndex];
                        }
                    }
                }
                else // Move backwards
                {
                    if (listIndex > 0 && listIndex <= _positions.Count - 1) // Prevents out of range error
                    {
                        listIndex--;
                        currentPosition = _positions[listIndex];
                    }
                }


                Console.WriteLine("---" + currentPosition);
            }
        }
        else _timer += _deltaTime;
    }
}