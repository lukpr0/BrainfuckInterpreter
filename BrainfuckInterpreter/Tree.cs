using System.Text;

namespace BrainfuckInterpreter;

public class Tree(Token token)
{
    public LinkedList<Tree> Children { get; } = [];

    public int Type => token.Type;
    public Token Token => token;
    
    public int Multiple { get; set; }
    
    public void AddChild(Tree child)
    {
        Children.AddLast(child);
    }

    public void AddChild(params Tree[] children)
    {
        foreach (var child in children)
        {
            Children.AddLast(child);
        }
        
    }

    public void AddChild(IEnumerable<Tree> children)
    {
        foreach (var child in children)
        {
            Children.AddLast(child);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append('(');

        if (Multiple > 1)
        {
            sb.Append(Multiple);
        }
        else
        {
            sb.Append(token.TypeName);
        }
        
        sb.Append(' ');
        
        foreach (var child in Children)
        {
            sb.Append(' ');
            if (child.Children.Count == 0)
            {
                sb.Append(child.Token.Short);
            }
            else
            {
                sb.Append(child);
            }
            
        }
        sb.Append(')');
        return sb.ToString();
    }

    public string SimpleAst()
    {
        var sb = new StringBuilder();
        sb.Append('(');
        
        if (Multiple > 1)
        {
            sb.Append(Multiple);
        }
        else
        {
            sb.Append(token.Short);
        }
        
        foreach (var child in Children)
        {
            sb.Append(' ');
            if (child.Children.Count == 0)
            {
                sb.Append(child.Token.Short);
            }
            else
            {
                sb.Append(child.SimpleAst());
            }
            
        }
        sb.Append(')');
        return sb.ToString();
    }
    
}