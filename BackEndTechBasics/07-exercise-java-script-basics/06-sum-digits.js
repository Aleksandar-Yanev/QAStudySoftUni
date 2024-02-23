function solve(number) {
    'use strict';

    let sum = 0;
    let digit;
    while (number != 0) {
        digit = number % 10;
        sum += digit;
        number = Math.floor(number / 10);
    }
    console.log(sum);
}

solve(12345);