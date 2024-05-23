namespace BrainfuckInterpreter;

public class BrainfuckParser(TokenBuffer buffer)
{
    private TokenBuffer _in = buffer;

    public Tree? ParseProgram()
    {
        Tree? statlist;
        if ((statlist = ParseStatlist()) is not null)
        {
            var program = new Tree(new Token(Token.Program));
            program.AddChild(statlist.Children);
            return program;
        }
        return null;
    }

    private Tree? ParseStatlist()
    { 
        var token = _in.Peek();
        var tree = new Tree(new Token(Token.Statlist));
        Tree? stat;
        while (token.Type is not (Token.Eof or Token.RightBracket) && (stat = ParseStatement()) is not null)
        {
            tree.AddChild(stat);
            token = _in.Peek();
        }

        return tree;
    }

    private Tree? ParseStatement()
    {
        var token = _in.Peek();
        var stat = token.Type switch
        {
            Token.PtrInc => ParseToken(Token.PtrInc),
            Token.PtrDec => ParseToken(Token.PtrDec),
            Token.Inc => ParseToken(Token.Inc),
            Token.Dec => ParseToken(Token.Dec),
            Token.Read => ParseToken(Token.Read),
            Token.Write => ParseToken(Token.Write),
            Token.LeftBracket => ParseLoop(),
            _ => throw new ArgumentException()
        };

        return stat;
    }

    private Tree? ParseToken(int type)
    {
        var token = _in.Peek();
        if (token.Type == type)
        {
            return new Tree(_in.Read());
        }


        return null;
    }

    private Tree? ParseLoop()
    {
        Tree? statlist;
        if (ParseToken(Token.LeftBracket) is not null
            && (statlist = ParseStatlist()) is not null
            && ParseToken(Token.RightBracket) is not null)
        {
            Tree loop = new Tree(new Token(Token.Loop));
            loop.AddChild(statlist.Children);
            return loop;
        }
        return null;
    }
}