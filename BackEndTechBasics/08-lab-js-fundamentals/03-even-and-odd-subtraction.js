function substraction(arrInput) {
    'use strict';
  
    let sumOdd = 0;
    let sumEven = 0;

    for (let j = 0; j < arrInput.length; j++) {
        let currentNumber = Number(arrInput[j]);
        if (currentNumber % 2 == 0) {
            sumEven += currentNumber;
        } else {
            sumOdd += currentNumber;
        }
    }

    let difference = sumEven - sumOdd;
    console.log(difference);
}

substraction([1,2,3,4,5,6]);
substraction([3,5,7,9]);
substraction([2,4,6,8,10]);