// Your program should start at this line.
int openRoads = 0;
int circlingPrevention = 0;
int turnCount = 0;
int previousStraight = 0;
Random random = new Random();

scan();

while(!AtGoal())
{
    Move(); //Note to self. Idea could be to alwas have a scan check for the left/right to make the car hug the wall to the goal.
}


#region Basic functions
// These functions are just her to make your intelisense work. 
// They only have a conceptual function.


void oneWayStreet()
{
    //Mark current location to return false on peek check.
}

void scan()
{
    openRoads = 0;
    for (int i = 0; i < 4; i++)
    {
        Peek();
        if (peek() == true)
        {
            openRoads++;
        }
        Turn();
    }
    markTile();    
}
void markTile()
{
    //Mark tile with the number of {openRoads} found from the scan.
    circlingPrevention++; //In case of a maze with a roundout within it to prevent looping. Mark tile so it is not passed more than a set amount of times.
    previousStraight++;
}

void Move()
{
    if (circlingPrevention == 50)
    {
        oneWayStreet();
    }

    if (previousStraight == 1)
    {
        int randomTurns = random.Next(1, 3);
        for (int i = 0; i < randomTurns; i++)
        {
            Turn();
        }
    }

    Peek();
    if (Peek() == false)
    {
        Turn();
        Move();
    }
    else
    {
        // Moves the car 1 cell in the direction it is heading.
        scan();
        if (openRoads == 1)
        {
            Turn();
            Turn();
            oneWayStreet();
        }
    }
}

void Turn()
{
    // Turns the car 90 deg clockwise.
}

bool Peek()
{
    // Return true if the next cell is open, otherwise false.
    return true; // Just a placeholder value. 
}


bool AtGoal()
{
    // Returns true if the current cell is the goal cell.
    return true; // just a placholder
}

#endregion