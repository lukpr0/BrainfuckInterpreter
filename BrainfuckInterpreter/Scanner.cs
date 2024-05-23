namespace BrainfuckInterpreter;

public class Scanner(StringReader sr)
{
    private StringReader _in = sr;

    public Token NextToken()
    {
        Token? token = null;
        while (token is null)
        {
            token = _in.Read() switch
            {
                '>' => new Token(Token.PtrInc),
                '<' => new Token(Token.PtrDec),
                '+' => new Token(Token.Inc),
                '-' => new Token(Token.Dec),
                '.' => new Token(Token.Write),
                ',' => new Token(Token.Read),
                '[' => new Token(Token.LeftBracket),
                ']' => new Token(Token.RightBracket),
                -1 => new Token(Token.Eof),
                _ => null,
            };
        }

        return token;
    }
}