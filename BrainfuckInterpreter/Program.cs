// See https://aka.ms/new-console-template for more information
using BrainfuckInterpreter;

const string program = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.+++.";
//const string program = "+++[]";

var reader = new StringReader(program);
var scanner = new Scanner(reader);
var buffer = new TokenBuffer(scanner);
var parser = new BrainfuckParser(buffer);
//var interpreter = new Interpreter(parser);

//var p =parser.ParseProgram();

//Console.WriteLine(p.SimpleAst());

var transformer = new BrainfuckTransformer(parser);
var p =transformer.Simplify();
Console.WriteLine(p.SimpleAst());

/*interpreter.Run();
interpreter.Info();

/*Token token;
do
{
    token = scanner.NextToken();
    Console.WriteLine(token.TypeName);
} while (token.Type != Token.Eof);*/



