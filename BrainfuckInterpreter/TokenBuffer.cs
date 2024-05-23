namespace BrainfuckInterpreter;

public class TokenBuffer(Scanner scanner)
{

    private Token _token = scanner.NextToken();

    public Token Peek()
    {
        return _token;
    }

    public Token Read()
    {
        var token = _token;
        if (token.Type != Token.Eof)
        {
            _token = scanner.NextToken();
            return token;
        }

        return _token;
    }
    
}