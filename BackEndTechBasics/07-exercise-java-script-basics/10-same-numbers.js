function solve (number){
    'use strict';

    let sum = 0;
    let digitIsSame = true;

    const firstDigit = number % 10;

    while (number > 0){
        const currentDigit = number % 10;

        if (firstDigit !== currentDigit){
            digitIsSame = false;
        }

        sum += currentDigit;
        number = Math.floor(number / 10);
    }

    console.log (digitIsSame);
    console.log (sum);
}    

solve (2222222);