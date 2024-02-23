function solve(parameter1, parameter2) {
    'use strict';

    let sum = 0
    let numbers = '';
    for (let i = parameter1; i <= parameter2; i++) {
        
        numbers += `${i} `;
        sum += i;
    }
    console.log(numbers.trimEnd());
    console.log(`Sum: ${sum}`);
}