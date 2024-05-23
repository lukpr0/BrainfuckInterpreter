using System.Text;

namespace BrainfuckInterpreter;

public class Interpreter
{
    private List<byte> _array = [0];
    private int _position = 0;

    private Tree _program;

    public Interpreter(BrainfuckParser parser)
    {
        var program = parser.ParseProgram();
        if (program is null)
        {
            throw new Exception();
        }
        _program = program;
    }
    
    public void Run()
    {
        RunList(_program);
    }

    private void RunStatement(Tree statement)
    {
        switch (statement.Type)
        {
            case Token.Inc: _array[_position]++; break;
            case Token.Dec: _array[_position]--; break;
            case Token.PtrInc:
                _position++;
                if (_array.Count == _position)
                {
                    _array.Add(0);
                }
                break;
            case Token.PtrDec:
                _position--;
                if (_position < 0)
                {
                    throw new Exception();
                }
                break;
            case Token.Write:
                string c = Encoding.ASCII.GetString([_array[_position]]);
                Console.Write(c);
                break;
            case Token.Loop:
                while (_array[_position] != 0)
                {
                    RunList(statement);
                }
                break;
        }
    }
    
    private void RunList(Tree list)
    {
        foreach (var child in list.Children)
        {
            RunStatement(child);
        }
    }

    public void Info()
    {
        Console.WriteLine($"\r\nDP: {_position}");
    }
}