function solve(arrayOfStrings, number) {
    'use strict';
    let returnedArray = [];
    for (let index = 0; index <= arrayOfStrings.length -1; index += number) {
        returnedArray.push(arrayOfStrings[index]);
    }
    return returnedArray
}

console.log(solve(['5', '20', '31', '4', '20'], 2));