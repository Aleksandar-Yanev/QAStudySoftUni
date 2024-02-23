function largestNumber (numberOne, numberTwo, numberThree){
    'use strict'
    const maxNumber = Math.max(numberOne, numberTwo, numberThree);
    console.log(`The largest number is ${maxNumber}.`)
}

largestNumber(3, -2, 15);