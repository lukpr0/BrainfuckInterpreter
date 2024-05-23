namespace BrainfuckInterpreter;

public class BrainfuckTransformer(BrainfuckParser parser)
{

    public Tree Simplify()
    {
        var tree = parser.ParseProgram();
        if (tree is null)
        {
            throw new Exception();
        }

        return Simplify(tree);
    }
    
    Tree Simplify(Tree tree)
    {
        var last = new Tree( new Token(Token.Invalid));
        var counter = 1;
        var newTree = new Tree(tree.Token);
        foreach (var child in tree.Children)
        {
            if (child.Type == last.Type)
            {
                counter++;
            }
            else if (counter > 1)
            {
                var simplified = new Tree(new Token(Token.Multi))
                {
                    Multiple = counter
                };
                simplified.AddChild(last);
                newTree.AddChild(simplified);
                counter = 1;
            }
            else if (last.Type != Token.Invalid)
            {
                newTree.AddChild(Simplify(last));
                counter = 1;
            }

            last = child;

        }
        
        if (last.Type != Token.Invalid)
        {
            newTree.AddChild(Simplify(last));
        }
        
        return newTree;
    }
}