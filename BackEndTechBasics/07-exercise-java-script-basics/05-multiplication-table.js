function solve(number) {
    'use strict';
    let result = 0;

    for (let i = 1; i <= 10; i++) {
        result = number * i;
        console.log(`${number} X ${i} = ${result}`);
    }
}