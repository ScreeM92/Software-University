function calcExpression(){
    var expression = document.getElementById("input").value;
    expression.split(/\D/);
    var expressionResult = eval(expression);

    document.getElementById("result").innerHTML = expressionResult;
}
