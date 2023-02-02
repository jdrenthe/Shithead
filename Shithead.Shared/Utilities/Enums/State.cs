namespace Shithead.Shared.Utilities.Enums
{
    public enum State
    {
        // Is the stack where cards are pulled from
        Stack = 0,

        // Is the plile where cards are played on
        Pile = 1,

        // Is the Trash pile where cards are when they ar out of the game
        Trash = 2,

        // Are the hand of the player cards that can be played
        Hand = 3,

        // Are the open cards of the player on the table/screen 
        Open = 4,

        // Are the closed cards of the player on the table/screen 
        Closed = 5,

        // Are the cards blocking the pile because they are played before there turn or are invalid
        Blocked = 6
    }
}
