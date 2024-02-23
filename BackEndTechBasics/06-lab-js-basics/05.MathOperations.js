function mathOperations (number1, number2, operand){
    'use strict';
    let result = undefined;

    switch(operand){
        case '+':
            result = number1 + number2;
            break;
        case '-':
            result = number1 - number2;
            break;
        case '*':
            result = number1 * number2;
            break;
        case '/':
            result = number1 / number2;
            break;
        case '%':
            result = number1 % number2;
            break;
        case '**':
            result = number1 ** number2;
            break;
    }
    console.log(result);
}