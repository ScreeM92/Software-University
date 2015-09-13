using System;
using System.Windows.Forms;

class AnnonymousMethods
{
    void ShowMsg(string msg)
    {
        MessageBox.Show(msg);
    }

    void InvokeDelegate()
    {
        Action<string> action = ShowMsg;
        action("I am called by a delegate.");
    }

    void InvokeAnnonymousMethod()
    {
        Action<string> action = delegate(string msg)
        {
            MessageBox.Show(msg);
        };
        action("I am called by an annonymous method.");
    }

    void InvokeLambdaFunction()
    {
        Action<string> action = (msg) =>
        {
            MessageBox.Show(msg);
        };
        action("I am called by a lambda function.");
    }

    static void Main()
    {
        AnnonymousMethods example = new AnnonymousMethods();
        example.InvokeDelegate();
        example.InvokeAnnonymousMethod();
        example.InvokeLambdaFunction();
    }
}
