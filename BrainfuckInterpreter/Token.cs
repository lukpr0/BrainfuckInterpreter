namespace BrainfuckInterpreter;

public class Token(int type)
{
    public const int PtrInc = 1;
    public const int PtrDec = 2;
    public const int Inc = 3;
    public const int Dec = 4;
    public const int Write = 5;
    public const int Read = 6;
    public const int LeftBracket = 7;
    public const int RightBracket = 8;
    public const int Eof = -1;
    public const int Invalid = 0;
    public const int Program = 9;
    public const int Statlist = 10;
    public const int Loop = 11;
    public const int Multi = 12;
    public const int Number = 13;
    
    public int Type { get; set; } = type;

    public string TypeName => Type switch
    {
        PtrInc => "PtrInc",
        PtrDec => "PtrDec",
        Inc => "Inc",
        Dec => "Dec",
        Write => "Write",
        Read => "Read",
        LeftBracket => "Left Bracket",
        RightBracket => "Right Bracket",
        Eof => "End of file",
        Invalid => "Invalid",
        Program => "Program",
        Statlist => "Statlist",
        Loop => "Loop",
        Multi => "Multiple",
        _ => throw new ArgumentException()
    };

    public string Short => Type switch
    {
        PtrInc => ">",
        PtrDec => "<",
        Inc => "+",
        Dec => "-",
        Write => ".",
        Read => ",",
        LeftBracket => "[",
        RightBracket => "]",
        Eof => "<<EOF>>",
        Invalid => "<<invalid>>",
        Program => "BF:",
        Statlist => "",
        Loop => "[]",
        Multi => "X"
    };


}